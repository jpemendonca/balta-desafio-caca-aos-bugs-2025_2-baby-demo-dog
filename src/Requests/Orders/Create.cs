using System.ComponentModel.DataAnnotations;

namespace BugStore.Requests.Orders;

public class Create
{
    [Required]
    public Guid CustomerId { get; set; }
    
    [Required]
    [MinLength(1)]
    public List<LineItemRequest> Lines { get; set; } = new();
}