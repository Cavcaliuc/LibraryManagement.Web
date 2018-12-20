using System;

namespace LibraryManagement.Web.Models
{
    public class Message : Entity
    {
        public virtual Order Order { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Text { get; set; }
    }
}