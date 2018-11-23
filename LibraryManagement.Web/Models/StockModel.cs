using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Web.Models
{
    public class StockModel : Entity
    {
        public long ItemId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Category")]
        public short CategoryId { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        public long PublisherId { get; set; }

        [Display(Name = "Publisher")]
        [Required]
        public string PublisherName { get; set; }

        public long AuthorId { get; set; }

        [Required]
        public string AuthorFirstName { get; set; }

        [Required]
        public string AuthorLastName { get; set; }

        [Display(Name = "Author")]
        public string AuthorFullName
        {
            get { return $"{AuthorFirstName} {AuthorLastName}"; }
        }

        [Required]
        public long Year { get; set; }

        [Display(Name = "Owner")]
        public string OwnerUserName { get; set; }

        public string OwnerId { get; set; }

        [Required]
        public short ActionTypeId { get; set; }

        [Display(Name = "Action Type")]
        public string ActionTypeName { get; set; }

        [Required]
        public short ConditionId { get; set; }

        [Display(Name = "Condition")]
        public string ConditionName { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}