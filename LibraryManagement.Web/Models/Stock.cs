using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Web.Models
{
    public class Stock : Entity
    {
        [Required]
        public long ItemId { get; set; }

        public virtual Item Item { get; set; }

        [ScaffoldColumn(false)]
        public virtual ApplicationUser Owner { get; set; }

        [Required]
        public short ActionTypeId { get; set; }
        public virtual ActionType ActionType { get; set; }

        [Required]
        public short ConditionId { get; set; }
        public virtual Condition Condition { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}