using BugStore.Handlers.Customers;
using Microsoft.AspNetCore.Mvc;

namespace BugStore.Endpoints.Customer;

public static class CustomerEndpoints
{
    public static void MapCustomerEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/v1/customers");
        group.WithTags("Customers");
        
        group.MapGet("/", async (
                [FromServices] ICustomerHandler handler) => 
            await handler.GetAllAsync());

        group.MapGet("/{id}", async (
                [FromRoute] Guid id, 
                [FromServices] ICustomerHandler handler) => 
            await handler.GetByIdAsync(id));
        
        group.MapPost("/", async (
                [FromBody] BugStore.Requests.Customers.Create request, 
                [FromServices] ICustomerHandler handler) => 
            await handler.CreateAsync(request));
        
        group.MapPut("/{id}", async (
                [FromRoute] Guid id, 
                [FromBody] BugStore.Requests.Customers.Update request, 
                [FromServices] ICustomerHandler handler) => 
            await handler.UpdateAsync(id, request));
        
        group.MapDelete("/{id}", async (
                [FromRoute] Guid id, 
                [FromServices] ICustomerHandler handler) => 
            await handler.DeleteAsync(id));
    }
}