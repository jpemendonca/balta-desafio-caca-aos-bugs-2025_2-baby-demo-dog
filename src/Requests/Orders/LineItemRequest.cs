﻿using System.ComponentModel.DataAnnotations;

namespace BugStore.Requests.Orders;

public class LineItemRequest
{
    [Required]
    public Guid ProductId { get; set; }
    
    [Range(1, 100)]
    public int Quantity { get; set; }
}