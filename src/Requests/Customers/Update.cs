using System.ComponentModel.DataAnnotations;

namespace BugStore.Requests.Customers;

public class Update
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}