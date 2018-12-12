using System;

namespace LibraryManagement.Web.Models
{
    public class Order : Entity
    {
        public virtual Stock Stock { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ApplicationUser ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public int Quantity { get; set; }
    }
}