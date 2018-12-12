namespace LibraryManagement.Web.Models
{
    public class OrderStatus : Lookup
    {
        public const string Pending = "Pending";
        public const string Closed = "Closed";
        public const string Canceled = "Canceled";
    }
}