using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using crud.Data.Models;
using crud_postgre.ViewModels;
using crud_postgre.Interfaces;

namespace CustomerService.Impl
{
    public class CustomerServices(dbContext context, IWebHostEnvironment environment) : ICustomerService
    {
        private readonly dbContext _dbContext = context;
        private readonly IWebHostEnvironment _environment = environment;
        #region Add Customer
        public async Task<CustomerResponse> AddCustomer(RequestAddCustomer request)
        {
            DateTime aDate = DateTime.UtcNow;
            CustomerResponse CustomerRes = new();

            try
            {
                var checkdata = context.Customer.Where(x => x.customerName == request.customerName).FirstOrDefault();
                if (checkdata == null)
                {
                    Customer insertCustomer = new Customer
                    {
                        customerCode = request.customerCode,
                        customerName = request.customerName,
                        customerAddress = request.customerAddress,
                        createdBy = request.createdBy,
                        createdAt = aDate
                    };
                    context.Customer.Add(insertCustomer);
                    context.SaveChanges();


                    CustomerRes.transactionId = crud_postgre.Constants.ResponseConstant.Success;
                    CustomerRes.message = crud_postgre.Constants.ResponseConstant.SubmitSuccess;
                }
                else
                {
                    CustomerRes.transactionId = crud_postgre.Constants.ResponseConstant.Failed;
                    CustomerRes.message = crud_postgre.Constants.ResponseConstant.CustNameExist;
                }

            }
            catch (Exception ex)
            {
                string errmsg = ex.Message;
                if (errmsg.IndexOf(crud_postgre.Constants.ResponseConstant.LastQuery) > 0)
                    errmsg = errmsg.Substring(0, errmsg.IndexOf(crud_postgre.Constants.ResponseConstant.LastQuery));

                CustomerRes.transactionId = crud_postgre.Constants.ResponseConstant.Failed;
                CustomerRes.message = errmsg;
            }

            return CustomerRes;
        }
        #endregion

        #region Edit Customer
        public async Task<CustomerResponse> EditCustomer(RequestCustomer request)
        {
            DateTime aDate = DateTime.UtcNow;
            CustomerResponse CustomerRes = new();

            try
            {
                var dataCustomer = context.Customer.Where(x => x.customerId == request.customerId).FirstOrDefault();
                if (dataCustomer != null)
                {
                    dataCustomer.customerCode = request.customerCode;
                    dataCustomer.customerName = request.customerName;
                    dataCustomer.customerAddress = request.customerAddress;
                    dataCustomer.modifiedBy = request.modifiedBy;
                    dataCustomer.modifiedAt = aDate;
                    context.Customer.Update(dataCustomer);
                    context.SaveChanges();


                    CustomerRes.transactionId = crud_postgre.Constants.ResponseConstant.Success;
                    CustomerRes.message = crud_postgre.Constants.ResponseConstant.SubmitSuccess;
                }
                else
                {
                    CustomerRes.transactionId = crud_postgre.Constants.ResponseConstant.Failed;
                    CustomerRes.message = crud_postgre.Constants.ResponseConstant.SubmitFailed;
                }

            }
            catch (Exception ex)
            {
                string errmsg = ex.Message;
                if (errmsg.IndexOf(crud_postgre.Constants.ResponseConstant.LastQuery) > 0)
                    errmsg = errmsg.Substring(0, errmsg.IndexOf(crud_postgre.Constants.ResponseConstant.LastQuery));

                CustomerRes.transactionId = crud_postgre.Constants.ResponseConstant.Failed;
                CustomerRes.message = errmsg;
            }

            return CustomerRes;
        }
        #endregion

        #region Delete
        public async Task<CustomerResponse> DeleteCustomer(RequestId request)
        {
            CustomerResponse CustomerRes = new();
            DataCustomer dataCustomer = new();

            try
            {
                var getData = context.Customer.Where(x => x.customerId == request.customerId).FirstOrDefault();
                if (getData != null)
                {
                    context.Customer.Remove(getData);
                    context.SaveChanges();

                    CustomerRes.transactionId = crud_postgre.Constants.ResponseConstant.Success;
                    CustomerRes.message = crud_postgre.Constants.ResponseConstant.DeleteSuccess;
                }
                else
                {
                    CustomerRes.transactionId = crud_postgre.Constants.ResponseConstant.NotFound;
                    CustomerRes.message = crud_postgre.Constants.ResponseConstant.NotFound;
                }
            }
            catch (Exception ex)
            {
                string errmsg = ex.Message;
                if (errmsg.IndexOf(crud_postgre.Constants.ResponseConstant.LastQuery) > 0)
                    errmsg = errmsg.Substring(0, errmsg.IndexOf(crud_postgre.Constants.ResponseConstant.LastQuery));

                CustomerRes.transactionId = crud_postgre.Constants.ResponseConstant.Failed;
                CustomerRes.message = errmsg;
            }
            return CustomerRes;
        }
        #endregion

        #region Get Customer By Id
        public async Task<CustomerResponse> GetCustomerById(RequestId request)
        {
            CustomerResponse CustomerRes = new();
            DataCustomer dataCustomer = new();


            try
            {
                var getData = context.Customer.Where(x => x.customerId == request.customerId).FirstOrDefault();

                if (getData != null)
                {
                    dataCustomer = new()
                    {
                        customerId = getData.customerId,
                        customerCode = getData.customerCode,
                        customerName = getData.customerName,
                        customerAddress = getData.customerAddress,
                        createdAt = getData.createdAt,
                        createdBy = getData.createdBy
                    };
                    CustomerRes.transactionId= crud_postgre.Constants.ResponseConstant.Success;
                    CustomerRes.message= crud_postgre.Constants.ResponseConstant.DataFound;
                    CustomerRes.data = dataCustomer;
                }
                else
                {
                    CustomerRes.transactionId = crud_postgre.Constants.ResponseConstant.NotFound;
                    CustomerRes.message = crud_postgre.Constants.ResponseConstant.NotFound;
                }
            }
            catch (Exception ex) 
            {
                string errmsg = ex.Message;
                if (errmsg.IndexOf(crud_postgre.Constants.ResponseConstant.LastQuery) > 0)
                    errmsg = errmsg.Substring(0, errmsg.IndexOf(crud_postgre.Constants.ResponseConstant.LastQuery));

                CustomerRes.transactionId = crud_postgre.Constants.ResponseConstant.Failed;
                CustomerRes.message = errmsg;
            }
            return CustomerRes;
        }
        #endregion

        #region Get Customer List
        public async Task<CustomerResponseList> GetCustomerList(RequestId request)
        {
            CustomerResponseList CustomerRes = new();
            List<DataCustomer> listCustomer = [];

            try
            {
                var getData = context.Customer.ToList();
                if (getData != null && getData.Any())
                {
                    foreach (var result in getData)
                    {
                        DataCustomer Customer = new()
                        {
                            customerId = result.customerId,
                            customerCode = result.customerCode,
                            customerName = result.customerName,
                            customerAddress = result.customerAddress,
                            createdAt = result.createdAt,
                            createdBy = result.createdBy,
                        };
                        listCustomer.Add(Customer);
                    };

                    CustomerRes.transactionId = crud_postgre.Constants.ResponseConstant.Success;
                    CustomerRes.message = crud_postgre.Constants.ResponseConstant.DataFound;
                    CustomerRes.data = listCustomer;
                }
                else
                {
                    CustomerRes.transactionId = crud_postgre.Constants.ResponseConstant.NotFound;
                    CustomerRes.message = crud_postgre.Constants.ResponseConstant.NotFound;
                }
            }
            catch (Exception ex)
            {
                string errmsg = ex.Message;
                if (errmsg.IndexOf(crud_postgre.Constants.ResponseConstant.LastQuery) > 0)
                    errmsg = errmsg.Substring(0, errmsg.IndexOf(crud_postgre.Constants.ResponseConstant.LastQuery));

                CustomerRes.transactionId = crud_postgre.Constants.ResponseConstant.Failed;
                CustomerRes.message = errmsg;
            }
            return CustomerRes;
        }
        #endregion

    }
}
