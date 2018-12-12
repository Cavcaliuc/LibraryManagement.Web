using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Web.Models
{
    public class OrderModel : StockModel
    {
        public long OrderId { get; set; }

        public long StockId { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedById { get; set; }

        public string CreatedByName { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string ModifiedById { get; set; }

        public string ModifiedByName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        [Required]
        [Display(Name = "Order quantity")]
        public int OrderQuantity { get; set; }

        [Required]
        public short OrderStatusId { get; set; }

        public string OrderStatusName { get; set; }
    }
}
