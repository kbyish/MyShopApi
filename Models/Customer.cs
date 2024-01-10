using System.ComponentModel.DataAnnotations;
namespace MyShop.Models;
public class Customer
{
    public long Id { get; set; }
    public string? FirstName { get; set; }

    public required string LastName { get; set; }

    public string? Email { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? LastUpdate { get; set; }

}