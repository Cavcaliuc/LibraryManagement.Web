using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Web.Models
{
    public class OrderModel : StockModel
    {
        public OrderModel()
        {
            this.Messages = new List<MessageModel>();
        }

        public long OrderId { get; set; }

        public long StockId { get; set; }

        [Display(Name = "Order Date")]
        public DateTime CreatedDate { get; set; }

        public string CreatedById { get; set; }

        [Display(Name = "Ordered By")]
        public string CreatedByName { get; set; }

        [Display(Name = "Modified Date")]
        public DateTime? ModifiedDate { get; set; }

        public string ModifiedById { get; set; }

        [Display(Name = "Modified By")]
        public string ModifiedByName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        [Required]
        [Display(Name = "Order quantity")]
        public int OrderQuantity { get; set; }

        [Required]
        public short OrderStatusId { get; set; }

        [Display(Name = "Status")]
        public string OrderStatusName { get; set; }

        public List<MessageModel> Messages { get; set; }
    }
}
