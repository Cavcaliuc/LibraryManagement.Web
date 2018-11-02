namespace LibraryManagement.Web.Models
{
    public class Item : Entity
    {
      public string Title { get; set; } 
      public long OrdersCount { get; set; }
      public virtual Category Category { get; set; }
      public virtual Publisher Publisher { get; set; } 
    } 
}