using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShop.Models;

namespace MyShop.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class CustomersController(CustomerContext customerContext) : ControllerBase
{

    private readonly CustomerContext customerContext = customerContext;

    [HttpGet]
    [Route("GetCustomers")]
    public List<Customer> GetCustomers()
    {
        return customerContext.Customers.ToList();
    }

    [HttpGet]
    [Route("GetCustomerById")]
    public Customer GetCustomerById(long Id)
    {
        return customerContext.Customers.Where(x => x.Id == Id).FirstOrDefault();
    }

    [HttpPost]
    [Route("AddCustomer")]
    public string AddCustomer(Customer customer)
    {
        customerContext.Customers.Add(customer);
        customerContext.SaveChanges();

        return $"Customer  {customer.FirstName} {customer.LastName}with ID={customer.Id} Has been  Added Successfully";
    }

    [HttpPut]
    [Route("UpdateCustomer")]
    public string UpdateCustomer(Customer customer)
    {
        Customer currentCustomer = customerContext.Customers.Where(x => x.Id == customer.Id).AsNoTracking().FirstOrDefault();

        customerContext.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        customerContext.SaveChanges();

        return $"Customer  {customer.FirstName} {customer.LastName}with ID={customer.Id} Has been  Updated Successfully";
    }



    [HttpDelete]
    [Route("DeleteCustomer")]
    public string DeleteCustomer(long Id)
    {
        Customer customer = customerContext.Customers.Where(x => x.Id == Id).FirstOrDefault();
        customerContext.Customers.Remove(customer);
        customerContext.SaveChanges();

        return $"Customer  {customer.FirstName} {customer.LastName}with ID={customer.Id} Has been  Updated Successfully";
    }

}