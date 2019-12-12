using System;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using LibraryManagement.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Text.RegularExpressions;
using CaptchaMvc.HtmlHelpers;
using Twilio.Rest.Taskrouter.V1.Workspace;

namespace LibraryManagement.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _applicationDbContext;
        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager,
            ApplicationDbContext applicationDbContext)
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
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            ApplicationUser user;
            var isEmailValid = Encryption.IsValidEmail(model.EmailOrUserName);
            if (isEmailValid)
            {
                // Require the user to have a confirmed email before they can log on.
                user = await UserManager.FindByEmailAsync(Encryption.EncryptionForEmail(model.EmailOrUserName));
                if (user == null)
                {
                    user = await UserManager.FindByEmailAsync(model.EmailOrUserName);
                    if (user != null) UpdateUserEmail(user.Id);

                }

            }
            else
                user = await UserManager.FindByNameAsync(model.EmailOrUserName);

            if (user != null)
            {
                if (!await UserManager.IsEmailConfirmedAsync(user.Id))
                {
                    string callbackUrl = await SendEmailConfirmationTokenAsync(user.Id, "Confirm your account-Resend");

                    ViewBag.errorMessage = "You must have a confirmed email to log on.";
                    return View("Error");
                }
                var result = await SignInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, shouldLockout: true);
                switch (result)
                {
                    case SignInStatus.Success:
                        return RedirectToLocal(returnUrl);
                    case SignInStatus.LockedOut:
                        return View("Lockout");
                    case SignInStatus.RequiresVerification:
                        return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                    case SignInStatus.Failure:
                    default:
                        ModelState.AddModelError("", "Invalid login attempt.");
                        return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }

        }
        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // The following code protects for brute force attacks against the two factor codes. 
            // If a user enters incorrect codes for a specified amount of time then the user account 
            // will be locked out for a specified amount of time. 
            // You can configure the account lockout settings in IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    {
                        var userId = await SignInManager.GetVerifiedUserIdAsync();
                        UpdateUserEmail(userId);
                        return RedirectToLocal(model.ReturnUrl);
                    }

                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Invalid code.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model, HttpPostedFileBase fileUpload)
        {
            if (ModelState.IsValid && this.IsCaptchaValid("Invalid captcha"))
            {
                var userLocation = GetOrSaveUserLocation(model);

                AddPhotoToViewModel(model, fileUpload);
                if (!ModelState.IsValid) return View(model);

                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    DateOfBirth = Encryption.Encrypt(model.DateOfBirth.ToString()),
                    Location = userLocation,
                    Photo = model.Photo,
                    PhotoThumbnail = model.PhotoThumbnail
                };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    //Assign Role to user Here     
                    await UserManager.AddToRoleAsync(user.Id, "RegularUser");

                    //For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                    //Send an email with this link
                    string callbackUrl = await SendEmailConfirmationTokenAsync(user.Id, "Confirm your account");

                    ViewBag.Message = "Check your email and confirm your account, you must be confirmed "
                         + "before you can log in.";

                    return View("Info");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);

            if (result.Succeeded)
            {
                UpdateUserEmail(userId);
            }
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }


        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByEmailAsync(Encryption.EncryptionForEmail(model.Email));
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("ForgotPasswordConfirmation");
                }

                UpdateUserEmail(user.Id, false);
                // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>");
                UpdateUserEmail(user.Id);

                return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByEmailAsync(Encryption.EncryptionForEmail((model.Email)));
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            UpdateUserEmail(user.Id, false);

            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                UpdateUserEmail(user.Id);
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            UpdateUserEmail(userId, false);

            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            ExternalLoginInfo loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel {UserName = loginInfo.DefaultUserName });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }

                var tempRegisterViewModel = new RegisterViewModel{
                    CountryId = model.CountryId,
                    CountryName = model.CountryName,
                    LocationId = model.LocationId,
                    LocationName = model.LocationName,
                    ParentLocationId = model.ParentLocationId,
                    ParentLocationName = model.ParentLocationName
                };
                var userLocation = GetOrSaveUserLocation(tempRegisterViewModel);

                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = info.Email,
                    DateOfBirth = Encryption.Encrypt(model.DateOfBirth.ToString()),
                    Location = userLocation,
                    Photo = model.Photo,
                    PhotoThumbnail = model.PhotoThumbnail,
                    EmailConfirmed = true
                };

                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(user.Id, "RegularUser");
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        UpdateUserEmail(user.Id);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Stocks");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult GetCountries(string term = "")
        {
            var titles = ApplicationDbContext.Countries.Where(x => x.Name.ToUpper().Contains(term.ToUpper())).OrderBy(x => x.Name).ToList();
            return Json(titles);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult GetCities(long countryId, string term = "")
        {
            var titles = ApplicationDbContext.Locations.Where(x => x.CountryId == countryId && !x.ParentLocationId.HasValue && x.Name.ToUpper().Contains(term.ToUpper())).OrderBy(x => x.Name).ToList();
            return Json(titles);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult GetLocations(long countryId, long cityId, string term = "")
        {
            var titles = ApplicationDbContext.Locations.Where(x => x.CountryId == countryId && x.ParentLocationId.HasValue && x.ParentLocationId == cityId
                                               && x.Name.ToUpper().Contains(term.ToUpper())).OrderBy(x => x.Name).ToList();
            return Json(titles);
        }

        private void AddPhotoToViewModel(RegisterViewModel model, HttpPostedFileBase fileUpload)
        {

            if (fileUpload != null && fileUpload.ContentLength > 0)
            {
                var fileName = Path.GetFileName(fileUpload.FileName);
                var fileExtension = Path.GetExtension(fileName);
                if ((fileExtension != ".jpg") && (fileExtension != ".gif") && (fileExtension != ".png"))
                {
                    ModelState.AddModelError("Photo","Please add a valid image file");
                    return;
                }
                //attach the uploaded image to the object before saving to Database
                //model.ImageMimeType = fileUpload.ContentLength;
                model.Photo = new byte[fileUpload.ContentLength];
                fileUpload.InputStream.Read(model.Photo, 0, fileUpload.ContentLength);

                //Save image to file
                var filename = fileUpload.FileName;
                var filePathOriginal = Server.MapPath("/Content/Uploads/Originals");
                var filePathThumbnail = Server.MapPath("/Content/Uploads/Thumbnails");
                string savedFileName = Path.Combine(filePathOriginal, filename);
                fileUpload.SaveAs(savedFileName);

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

        private Location GetOrSaveUserLocation(RegisterViewModel model)
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
            if (!string.IsNullOrWhiteSpace(model.LocationName))
            {
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
            }

            return userLocation;
        }

        private async Task<string> SendEmailConfirmationTokenAsync(string userID, string subject)
        {
            string code = await UserManager.GenerateEmailConfirmationTokenAsync(userID);
            var callbackUrl = Url.Action("ConfirmEmail", "Account",
               new { userId = userID, code = code }, protocol: Request.Url.Scheme);
            await UserManager.SendEmailAsync(userID, subject,
               "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

            return callbackUrl;
        }

        private void UpdateUserEmail(string userId, bool toEncrypt = true)
        {
            var savedUser = ApplicationDbContext.Users.FirstOrDefault(x => x.Id == userId);
            if (savedUser == null) return;

            savedUser.Email = toEncrypt ? Encryption.EncryptionForEmail(savedUser.Email) : Encryption.DecryptionForEmail(savedUser.Email);

            ApplicationDbContext.Entry(savedUser).State = EntityState.Modified;
            ApplicationDbContext.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }

                if (_applicationDbContext != null)
                {
                    _applicationDbContext.Dispose();
                    _applicationDbContext = null;
                }
            }

            base.Dispose(disposing);
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

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Stocks");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }

        #endregion
    }
}