namespace LibraryManagement.Web.Models
{
    public class Stock : Entity
    {
      public virtual Item Item { get; set; } 
      public virtual ApplicationUser Owner { get; set; }
      public virtual ActionType ActionType { get; set; } 
      public virtual Condition Condition { get; set; }
      public int Quantity { get; set; }

    } 
}