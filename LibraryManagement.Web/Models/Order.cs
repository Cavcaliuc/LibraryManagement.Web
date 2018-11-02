using System;

namespace LibraryManagement.Web.Models
{
    public class Order : Entity
    {
      public virtual Stock Stock { get; set; } 
      public virtual ApplicationUser CreatedBy { get; set; }
      public virtual DateTime CreatedDate { get; set; }
      public int Quantity { get; set; }

    } 
}