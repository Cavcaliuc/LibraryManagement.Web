﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace LibraryManagement.Web.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public long? CountryId { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string CountryName { get; set; }

        public long? ParentLocationId { get; set; }

        [Required]
        [Display(Name = "City")]
        public string ParentLocationName { get; set; }

        public long? LocationId { get; set; }

        [Display(Name = "Location")]
        public string LocationName { get; set; }


        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [DataType(DataType.Upload)]
        public byte[] Photo { get; set; }

        public byte[] PhotoThumbnail { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        //[Required]
        //[Display(Name = "User name")]
        //public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Email/UserName")]
        public string EmailOrUserName { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public long? CountryId { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string CountryName { get; set; }

        public long? ParentLocationId { get; set; }

        [Required]
        [Display(Name = "City")]
        public string ParentLocationName { get; set; }

        public long? LocationId { get; set; }

        [Display(Name = "Location")]
        public string LocationName { get; set; }


        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Upload File")]
        [AllowFileSize(FileSize = 3 * 1024 * 1024, ErrorMessage = "Maximum allowed file size is 10 MB")]
        public HttpPostedFileBase FileUpload { get; set; }

        [DataType(DataType.Upload)]
        public byte[] Photo { get; set; }

        public byte[] PhotoThumbnail { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

          }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
