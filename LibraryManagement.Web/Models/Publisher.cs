using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace LibraryManagement.Web.Models
{
    public class Publisher : Entity
    {
        [Index("IX_Name", IsUnique = true)]
        [StringLength(200)]
        [Required]
        [Remote("PublisherExists", "Publisher", ErrorMessage = "Publisher already in use")]
        public string Name { get; set; }

    }
}