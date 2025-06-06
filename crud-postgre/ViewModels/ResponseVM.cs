using System.Data;

namespace crud_postgre.ViewModels
{
    public class CustomerResponse
    {
        public string? message { get; set; }
        public string? transactionId { get; set; }
        public DataCustomer? data { get; set; }
    }


    public class CustomerResponseList
    {
        public string? message { get; set; }
        public string? transactionId { get; set; }
        public List<DataCustomer>? data { get; set; }
    }

    public class DataCustomer
    {
        public int? customerId { get; set; }
        public string? customerCode { get; set; }
        public string? customerName { get; set; }
        public string? customerAddress { get; set; }
        public int? createdBy { get; set; }
        public DateTime? createdAt { get; set; }
        public int? modifiedBy { get; set; }
        public DateTime? modifiedAt { get; set; }
    }
}
