namespace LibraryManagement.Web.Models
{
    public class Location : Entity
    {
        public string Name { get; set; }

        public virtual Country Country { get; set; }

        public virtual Location ParentLocation { get; set; }
    }
}