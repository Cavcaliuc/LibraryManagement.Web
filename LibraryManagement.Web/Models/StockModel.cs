using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Web.Models
{
    public class StockModel : Entity
    {
        public long? ItemId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Category")]
        public short CategoryId { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        public long? PublisherId { get; set; }

        [Display(Name = "Publisher")]
        [Required]
        public string PublisherName { get; set; }

        public long? AuthorId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string AuthorFirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string AuthorLastName { get; set; }

        [Display(Name = "Author")]
        public string AuthorFullName => $"{AuthorFirstName} {AuthorLastName}";

        public long? CountryId { get; set; }

        public string CountryName { get; set; }

        public long? ParentLocationId { get; set; }

        public string ParentLocationName { get; set; }

        public long? LocationId { get; set; }

        public string LocationName { get; set; }

        //public string LocationFullName => {CountryName},  {string.IsNullOrWhiteSpace(LocationName)?? ParentLocationName: ParentLocationName, LocationName}";

        public string LocationFullName
        {
            get { return string.IsNullOrWhiteSpace(ParentLocationName) ? $"{CountryName}, {LocationName}" : $"{CountryName}, {ParentLocationName}, {LocationName}"; }
        }
        [Required]
        [Range(1900, 2100, ErrorMessage = "{0} must be between {1} and {2}")]
        public long Year { get; set; }

        [Display(Name = "Owner")]
        public string OwnerUserName { get; set; }

        public string OwnerId { get; set; }

        [Required]
        [Display(Name = "Action Type")]
        public short ActionTypeId { get; set; }

        [Display(Name = "Action Type")]
        public string ActionTypeName { get; set; }

        [Required]
        [Display(Name = "Condition")]
        public short ConditionId { get; set; }

        [Display(Name = "Condition")]
        public string ConditionName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int Quantity { get; set; }
    }
}