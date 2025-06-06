
using crud_postgre.Interfaces;
using crud_postgre.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController(ICustomerService CustomerService) : ControllerBase
    {
        public readonly ICustomerService CustomerService = CustomerService;

        
        [HttpPost("AddCustomer")]
        public async Task<CustomerResponse> AddCustomer([FromBody] RequestAddCustomer request)
        {
            return await CustomerService.AddCustomer(request);
        }

        [HttpPost("EditCustomer")]
        public async Task<CustomerResponse> EditCustomer([FromBody] RequestCustomer request)
        {
            return await CustomerService.EditCustomer(request);
        }

        [HttpPost("DeleteCustomer")]
        public async Task<CustomerResponse> DeleteCustomer([FromBody] RequestId request)
        {
            return await CustomerService.DeleteCustomer(request);
        }

        [HttpPost("GetCustomerById")]
        public async Task<CustomerResponse> GetCustomerById([FromBody] RequestId request)
        {
            return await CustomerService.GetCustomerById(request);
        }

        [HttpPost("GetCustomerList")]
        public async Task<CustomerResponseList> GetCustomerList([FromBody] RequestId request)
        {
            return await CustomerService.GetCustomerList(request);
        }

    }
}
