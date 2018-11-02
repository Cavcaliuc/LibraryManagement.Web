using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Web.Models
{
    public abstract class Entity
    {
        [Key]
        public long Id { get; set; }

    }
}