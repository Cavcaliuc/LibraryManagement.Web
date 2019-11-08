using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Web.Models
{
    public class MessageModel: Entity
    {
        [Required]
        public long OrderId { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime CreatedDate { get; set; }
        public bool Seen { get; set; }
        public string ItemTitle { get; set; }
        public string UserName { get; set; }
        public string CreatedById { get; set; }
        
    }
}