using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Web.Models
{
    public class Lookup
    {
        [Key]
        public short Id { get; set; }

        //[Index(IsUnique = true)]
        public string Name { get; set; }
    }
}