using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using LibraryManagement.Web.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using SendGrid.Helpers.Mail;
using System.Diagnostics;
using System.Text.RegularExpressions;
using SendGrid;
using LibraryManagement.Web;

namespace LibraryManagement.Web
{
    public class EmailService : IIdentityMessageService
    {
        public async Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.
            await configSendGridasync(message);
        }
        private async Task configSendGridasync(IdentityMessage message)
        {
            var apiKey = System.Configuration.ConfigurationManager.AppSettings["mailAPIKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("ReadIT@readit.com", "ReadIT");
            var subject = message.Subject;
            var to = new EmailAddress(message.Destination, "User");
            var plainTextContent = message.Body;
            var htmlContent = message.Body;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            // Send the email.
            if (client != null)
            {
                await client.SendEmailAsync(msg);
            }
            else
            {
                Trace.TraceError("Failed to create Web transport.");
                await Task.FromResult(0);
            }
        }
    }
}


public interface ITwilioMessageSender
{
    Task SendMessageAsync(string to, string from, string body);
}
public class TwilioMessageSender : ITwilioMessageSender
{
    public TwilioMessageSender()
    {
        var accountsid = System.Configuration.ConfigurationManager.AppSettings["TWILIOSID"];
        var authToken = System.Configuration.ConfigurationManager.AppSettings["TWILIOTOKEN"];
        TwilioClient.Init(accountsid, authToken);
    }

    public async Task SendMessageAsync(string to, string from, string body)
    {
        await MessageResource.CreateAsync(new PhoneNumber(to),
                                          from: new PhoneNumber(from),
                                          body: body);
    }
}

public class SmsService : IIdentityMessageService
{
    private readonly ITwilioMessageSender _messageSender;

    public SmsService() : this(new TwilioMessageSender()) { }

    public SmsService(ITwilioMessageSender messageSender)
    {
        _messageSender = messageSender;
    }

    public async Task SendAsync(IdentityMessage message)//, bool needDencrytion = true
    {
        var to = isValidPhoneNo(message.Destination) ? message.Destination : Encryption.Decrypt(message.Destination);
        await _messageSender.SendMessageAsync(to,
                                              System.Configuration.ConfigurationManager.AppSettings["TWILIONUMBER"],
                                              message.Body);
    }

    private bool isValidPhoneNo(string messageDestination)
    {
        return Regex.IsMatch(messageDestination, @"^[\+]{0,1}[1-9]{1}[0-9]{7,11}$");

    }
}

// Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
public class ApplicationUserManager : UserManager<ApplicationUser>
{
    public ApplicationUserManager(IUserStore<ApplicationUser> store)
        : base(store)
    {
    }

    public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
    {
        var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
        // Configure validation logic for usernames
        manager.UserValidator = new UserValidator<ApplicationUser>(manager)
        {
            AllowOnlyAlphanumericUserNames = false,
            RequireUniqueEmail = true
        };

        // Configure validation logic for passwords
        manager.PasswordValidator = new PasswordValidator
        {
            RequiredLength = 8,
            RequireNonLetterOrDigit = true,
            RequireDigit = true,
            RequireLowercase = true,
            RequireUppercase = true,
        };

        // Configure user lockout defaults
        manager.UserLockoutEnabledByDefault = true;
        manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
        manager.MaxFailedAccessAttemptsBeforeLockout = 5;

        // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
        // You can write your own provider and plug it in here.
        manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
        {
            MessageFormat = "Your security code is {0}"
        });
        manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
        {
            Subject = "Security Code",
            BodyFormat = "Your security code is {0}"
        });
        manager.EmailService = new LibraryManagement.Web.EmailService();
        manager.SmsService = new SmsService();
        var dataProtectionProvider = options.DataProtectionProvider;
        if (dataProtectionProvider != null)
        {
            manager.UserTokenProvider =
                new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
        }
        return manager;
    }
}

// Configure the application sign-in manager which is used in this application.
public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
{
    public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
        : base(userManager, authenticationManager)
    {
    }

    public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
    {
        return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
    }

    public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
    {
        return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
    }
}

