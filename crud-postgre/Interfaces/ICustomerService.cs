using crud_postgre.ViewModels;

namespace crud_postgre.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerResponse> AddCustomer(RequestAddCustomer request);
        Task<CustomerResponse> EditCustomer(RequestCustomer request);
        Task<CustomerResponse> DeleteCustomer(RequestId request);
        Task<CustomerResponse> GetCustomerById(RequestId request);
        Task<CustomerResponseList> GetCustomerList(RequestId request);
    }
}
