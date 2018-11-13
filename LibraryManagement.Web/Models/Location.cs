using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Web.Models
{
    public class Location : Entity
    {
        [MaxLength(250)]
        [Required]
        public string Name { get; set; }

        [Required]
        public short CountryId { get; set; }
        public long? ParentLocationId { get; set; }
        public virtual Country Country { get; set; }
        public virtual Location ParentLocation { get; set; }
    }
}