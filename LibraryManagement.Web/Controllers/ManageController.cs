using System;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using LibraryManagement.Web.Models;

namespace LibraryManagement.Web.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _applicationDbContext;

        public ManageController()
        {
        }

        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, ApplicationDbContext applicationDbContext)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            ApplicationDbContext = applicationDbContext;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationDbContext ApplicationDbContext
        {
            get
            {
                return _applicationDbContext ?? HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            }
            private set
            {
                _applicationDbContext = value;
            }
        }

        //
        // GET: /Manage/Index
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.SetTwoFactorSuccess ? "Your two-factor authentication provider has been set."
                : message == ManageMessageId.Error ? "An error has occurred."
                : message == ManageMessageId.AddPhoneSuccess ? "Your phone number was added."
                : message == ManageMessageId.RemovePhoneSuccess ? "Your phone number was removed."
                : "";

            ManageAccountModel model = await GetManageAccountModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ManageAccountModel account)
        {
            string id = User.Identity.GetUserId();
            var currentUser = ApplicationDbContext.Users.FirstOrDefault(u => u.Id == id)
                              ?? throw new ArgumentNullException("User not found");
            var location = GetOrSaveUserLocation(account);

            AddPhotoToViewModel(account);

            if (currentUser.UserName != account.UserName)
            {
                currentUser.UserName = account.UserName;
            }

            if (currentUser.Location != location)
            {
                currentUser.Location = location;
            }

            if (currentUser.DateOfBirth != Encryption.Encrypt(account.DateOfBirth.ToString()))
            {
                currentUser.DateOfBirth = Encryption.Encrypt(account.DateOfBirth.ToString());
            }

            if (currentUser.Photo != account.Photo && account.Photo != null)
            {
                currentUser.Photo = account.Photo;
                currentUser.PhotoThumbnail = account.PhotoThumbnail;
            }

            ApplicationDbContext.Entry(currentUser).State = EntityState.Modified;
            ApplicationDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        //
        // POST: /Manage/RemoveLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemoveLogin(string loginProvider, string providerKey)
        {
            ManageMessageId? message;
            var result = await UserManager.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginProvider, providerKey));
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                message = ManageMessageId.RemoveLoginSuccess;
            }
            else
            {
                message = ManageMessageId.Error;
            }
            return RedirectToAction("ManageLogins", new { Message = message });
        }

        //
        // GET: /Manage/AddPhoneNumber
        public ActionResult AddPhoneNumber()
        {
            return View();
        }

        //
        // POST: /Manage/AddPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddPhoneNumber(AddPhoneNumberViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // Generate the token and send it
            var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), model.Number);
            if (UserManager.SmsService != null)
            {
                var message = new IdentityMessage
                {
                    Destination = model.Number,
                    Body = "Your security code is: " + code
                };
                await UserManager.SmsService.SendAsync(message);
            }
            return RedirectToAction("VerifyPhoneNumber", new VerifyPhoneNumberViewModel { PhoneNumber = model.Number });
        }

        //
        // POST: /Manage/EnableTwoFactorAuthentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EnableTwoFactorAuthentication()
        {
            var userId = User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            if (user != null)
            {
                await EnableTwoFactor(user, true);
            }
            return RedirectToAction("Index", "Manage");
        }

        //
        // POST: /Manage/DisableTwoFactorAuthentication
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DisableTwoFactorAuthentication()
        {
            //await UserManager.SetTwoFactorEnabledAsync(User.Identity.GetUserId(), false);
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await EnableTwoFactor(user, false);
            }
            return RedirectToAction("Index", "Manage");
        }


        //
        // GET: /Manage/VerifyPhoneNumber
        public async Task<ActionResult> VerifyPhoneNumber(string phoneNumber)
        {
            var code = await UserManager.GenerateChangePhoneNumberTokenAsync(User.Identity.GetUserId(), phoneNumber);
            // Send an SMS through the SMS provider to verify the phone number
            return phoneNumber == null ? View("Error") : View(new VerifyPhoneNumberViewModel { PhoneNumber = phoneNumber });
        }

        //
        // POST: /Manage/VerifyPhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyPhoneNumber(VerifyPhoneNumberViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = User.Identity.GetUserId();
            UpdateUserEmail(userId, false);
            var result = await UserManager.ChangePhoneNumberAsync(userId, model.PhoneNumber, model.Code);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(userId);
                if (user != null)
                {
                    user.PhoneNumber = Encryption.Encrypt(model.PhoneNumber);
                    user.Email = Encryption.EncryptionForEmail(user.Email);

                    ApplicationDbContext.Entry(user).State = EntityState.Modified;
                    ApplicationDbContext.SaveChanges();
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.AddPhoneSuccess });
            }
            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "Failed to verify phone");
            return View(model);
        }

        //
        // POST: /Manage/RemovePhoneNumber
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RemovePhoneNumber()
        {
            var result = await UserManager.SetPhoneNumberAsync(User.Identity.GetUserId(), null);
            if (!result.Succeeded)
            {
                return RedirectToAction("Index", new { Message = ManageMessageId.Error });
            }
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user != null)
            {
                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
            }
            return RedirectToAction("Index", new { Message = ManageMessageId.RemovePhoneSuccess });
        }

        //
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            UpdateUserEmail(User.Identity.GetUserId(), false);
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    UpdateUserEmail(User.Identity.GetUserId());

                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            return View(model);
        }

        //
        // GET: /Manage/SetPassword
        public ActionResult SetPassword()
        {
            return View();
        }

        //
        // POST: /Manage/SetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
                if (result.Succeeded)
                {
                    var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                    if (user != null)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    }
                    return RedirectToAction("Index", new { Message = ManageMessageId.SetPasswordSuccess });
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Manage/ManageLogins
        public async Task<ActionResult> ManageLogins(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user == null)
            {
                return View("Error");
            }
            var userLogins = await UserManager.GetLoginsAsync(User.Identity.GetUserId());
            var otherLogins = AuthenticationManager.GetExternalAuthenticationTypes().Where(auth => userLogins.All(ul => auth.AuthenticationType != ul.LoginProvider)).ToList();
            ViewBag.ShowRemoveButton = user.PasswordHash != null || userLogins.Count > 1;
            return View(new ManageLoginsViewModel
            {
                CurrentLogins = userLogins,
                OtherLogins = otherLogins
            });
        }

        //
        // POST: /Manage/LinkLogin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            return new AccountController.ChallengeResult(provider, Url.Action("LinkLoginCallback", "Manage"), User.Identity.GetUserId());
        }

        //
        // GET: /Manage/LinkLoginCallback
        public async Task<ActionResult> LinkLoginCallback()
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync(XsrfKey, User.Identity.GetUserId());
            if (loginInfo == null)
            {
                return RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
            }
            var result = await UserManager.AddLoginAsync(User.Identity.GetUserId(), loginInfo.Login);
            return result.Succeeded ? RedirectToAction("ManageLogins") : RedirectToAction("ManageLogins", new { Message = ManageMessageId.Error });
        }

        private void UpdateUserEmail(string userId, bool toEncrypt = true)
        {
            var savedUser = ApplicationDbContext.Users.FirstOrDefault(x => x.Id == userId);
            if (savedUser == null) return;

            savedUser.Email = toEncrypt ? Encryption.EncryptionForEmail(savedUser.Email) : Encryption.DecryptionForEmail(savedUser.Email);

            ApplicationDbContext.Entry(savedUser).State = EntityState.Modified;
            ApplicationDbContext.SaveChanges();
        }

        private async Task EnableTwoFactor(ApplicationUser user, bool enableTwoFactor)
        {
            user.TwoFactorEnabled = enableTwoFactor;
            ApplicationDbContext.Entry(user).State = EntityState.Modified;
            ApplicationDbContext.SaveChanges();
            await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
        }

        private void AddPhotoToViewModel(ManageAccountModel model)
        {

            if (model.FileUpload != null && model.FileUpload.ContentLength > 0)
            {
                var fileName = Path.GetFileName(model.FileUpload.FileName);
                var fileExtension = Path.GetExtension(fileName).ToLowerInvariant();
                if (fileExtension != ".jpg" && fileExtension != ".gif" && fileExtension != ".png" && fileExtension != ".jpeg")
                {
                    ModelState.AddModelError("Photo", "Please add a valid image file format");
                    return;
                }

                //attach the uploaded image to the object before saving to Database
                //model.ImageMimeType = fileUpload.ContentLength;
                model.Photo = new byte[model.FileUpload.ContentLength];
                model.FileUpload.InputStream.Read(model.Photo, 0, model.FileUpload.ContentLength);

                //Save image to file
                var filename = model.FileUpload.FileName;
                var filePathOriginal = Server.MapPath("/Content/Uploads/Originals");
                var filePathThumbnail = Server.MapPath("/Content/Uploads/Thumbnails");
                string savedFileName = Path.Combine(filePathOriginal, filename);
                model.FileUpload.SaveAs(savedFileName);

                //Read image back from file and create thumbnail from it
                var imageFile = Path.Combine(Server.MapPath("~/Content/Uploads/Originals"), filename);
                using (var srcImage = Image.FromFile(imageFile))
                using (var newImage = new Bitmap(100, 100))
                using (var graphics = Graphics.FromImage(newImage))
                using (var stream = new MemoryStream())
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    graphics.DrawImage(srcImage, new Rectangle(0, 0, 100, 100));
                    newImage.Save(stream, ImageFormat.Png);
                    var thumbNew = File(stream.ToArray(), "image/png");
                    model.PhotoThumbnail = thumbNew.FileContents;
                }
            }
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }
            if (_applicationDbContext != null)
            {
                _applicationDbContext.Dispose();
                _applicationDbContext = null;
            }

            base.Dispose(disposing);
        }

        private async Task<ManageAccountModel> GetManageAccountModel()
        {
            var userId = User.Identity.GetUserId();

            var phoneNumber = await UserManager.GetPhoneNumberAsync(userId);
            var model = new ManageAccountModel
            {
                HasPassword = HasPassword(),
                PhoneNumber = !string.IsNullOrWhiteSpace(phoneNumber) ? Encryption.Decrypt(phoneNumber) : phoneNumber,
                TwoFactor = await UserManager.GetTwoFactorEnabledAsync(userId),
                Logins = await UserManager.GetLoginsAsync(userId),
                BrowserRemembered = await AuthenticationManager.TwoFactorBrowserRememberedAsync(userId)
            };

            var user = ApplicationDbContext.Users
                .Include(s => s.Location)
                .FirstOrDefault(x => x.Id == userId);

            if (user != null)
            {
                model.UserName = user.UserName;
                model.Email = Encryption.DecryptionForEmail(user.Email);
                model.Photo = user.Photo;
                model.PhotoThumbnail = user.PhotoThumbnail;
                model.DateOfBirth = !string.IsNullOrWhiteSpace(user.DateOfBirth) ? DateTime.Parse(Encryption.Decrypt(user.DateOfBirth)) : (DateTime?)null;
                model.LocationId = user.Location?.Id;
                model.LocationName = user.Location?.Name;
                model.ParentLocationId = user.Location?.ParentLocation?.Id;
                model.ParentLocationName = user.Location?.ParentLocation?.Name;
                model.CountryId = user.Location?.Country.Id;
                model.CountryName = user.Location?.Country.Name;
            }
            return model;
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private bool HasPassword()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        private bool HasPhoneNumber()
        {
            var user = UserManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PhoneNumber != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }

        private Location GetOrSaveUserLocation(ManageAccountModel model)
        {
            var country = ApplicationDbContext.Countries.FirstOrDefault(x => x.Name.ToUpper() == model.CountryName.ToUpper());
            if (country == null)
            {
                country = ApplicationDbContext.Countries.Add(new Country { Name = model.CountryName });
                ApplicationDbContext.SaveChanges();
            }

            var parentLocation = ApplicationDbContext.Locations
                .Where(x => x.Name.ToUpper() == model.ParentLocationName.ToUpper())
                .Include(y => y.ParentLocation).Include(y => y.Country)
                .FirstOrDefault(x => x.CountryId == country.Id && !x.ParentLocationId.HasValue);

            if (parentLocation == null)
            {
                parentLocation =
                    ApplicationDbContext.Locations.Add(new Location { Name = model.ParentLocationName, Country = country });
                ApplicationDbContext.SaveChanges();
            }

            var userLocation = parentLocation;
            if (string.IsNullOrWhiteSpace(model.LocationName)) return userLocation;

            var location = ApplicationDbContext.Locations.Where(x => x.Name.ToUpper() == model.LocationName.ToUpper())
                .Include(y => y.ParentLocation)
                .FirstOrDefault(x => x.ParentLocationId.HasValue && x.ParentLocationId.Value == parentLocation.Id);

            if (location == null)
            {
                location = ApplicationDbContext.Locations.Add(
                    new Location { Name = model.LocationName, Country = country, ParentLocation = parentLocation });
                ApplicationDbContext.SaveChanges();
            }

            userLocation = location;
            return userLocation;
        }

        #endregion
    }
}
