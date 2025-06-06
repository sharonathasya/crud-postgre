using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crud_postgre.ViewModels
{
    public class RequestCustomer
    {

        public int customerId { get; set; }
        public string customerCode { get; set; }
        public string customerName { get; set; }
        public string customerAddress { get; set; }
        public int modifiedBy { get; set; }
    }

    public class RequestAddCustomer
    {
        public string customerCode { get; set; }
        public string customerName { get; set; }
        public string customerAddress { get; set; }
        public int createdBy { get; set; }
    }
    public class RequestId
    {
        public int? customerId { get; set; }
        public string? customerName { get; set; }
    }
}
