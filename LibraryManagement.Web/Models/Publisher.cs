using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Web.Models
{
    public class Publisher : Entity
    {
        [Index(IsUnique = true)]
        [StringLength(200)]
        [Required]
        public string Name { get; set; }

    }
}