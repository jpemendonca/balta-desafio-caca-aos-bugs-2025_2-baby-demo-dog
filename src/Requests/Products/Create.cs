using System.ComponentModel.DataAnnotations;

namespace BugStore.Requests.Products;

public class Create
{
    [Required]
    public string Title { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    [Range(0.01, (double)decimal.MaxValue)]
    public decimal Price { get; set; }
}