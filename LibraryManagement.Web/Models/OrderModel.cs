using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Web.Models
{
    public class OrderModel : StockModel
    {
        public long OrderId { get; set; }

        public long StockId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        [Required]
        [Display(Name = "Order quantity")]
        public int OrderQuantity { get; set; }
    }
}