using Microsoft.EntityFrameworkCore;
namespace MyShop.Models;

public class CustomerContext:DbContext{

    public CustomerContext(DbContextOptions dbContextOptions): base(dbContextOptions)
    {
        
    }

    public DbSet<Customer> Customers{get; set;}

}