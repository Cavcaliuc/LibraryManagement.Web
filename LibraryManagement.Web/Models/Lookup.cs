using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Web.Models
{
    public class Lookup
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public short Id { get; set; }

        [Index(IsUnique = true)]
        [StringLength(100)]
        [Required]
        public string Name { get; set; }

    }
}