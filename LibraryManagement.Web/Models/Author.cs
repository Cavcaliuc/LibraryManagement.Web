using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Web.Models
{
    public class Author : Entity
    {
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
    }
}