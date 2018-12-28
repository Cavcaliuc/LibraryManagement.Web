using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Web.Models
{
    public class Message : Entity
    {
        [Required]
        public long OrderId { get; set; }
        public virtual Order Order { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Seen { get; set; }

        [Required]
        public string Text { get; set; }
    }
}