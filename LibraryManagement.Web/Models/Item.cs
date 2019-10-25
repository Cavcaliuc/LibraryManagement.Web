using System.ComponentModel.DataAnnotations;
using System;

namespace LibraryManagement.Web.Models
{
    public class Item : Entity
    {
        [Required]
        public string Title { get; set; }

        [ScaffoldColumn(false)]
        public long OrdersCount { get; set; }

        [Required]
        [Display(Name = "Category")]
        public short CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        [Display(Name = "Publisher")]
        public long PublisherId { get; set; }

        public string PublisherName { get; set; }

        public virtual Publisher Publisher { get; set; }

        [Required]
        [Display(Name = "Author")]
        public long AuthorId { get; set; }

        public virtual Author Author { get; set; }

        [Required]
        [Range(1000, 2019)]
        public long Year { get; set; }

    }

}