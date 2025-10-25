using BugStore.Handlers.Customers;
using Microsoft.AspNetCore.Mvc;

namespace BugStore.Endpoints.Customer;

public static class CustomerEndpoints
{
    public static void MapCustomerEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/v1/customers", async (
                [FromServices] ICustomerHandler handler) =>
            await handler.GetAllAsync());

        app.MapGet("/v1/customers/{id}", async (
                [FromRoute] Guid id,
                [FromServices] ICustomerHandler handler) =>
            await handler.GetByIdAsync(id));

        app.MapPost("/v1/customers", async (
                [FromBody] BugStore.Requests.Customers.Create request,
                [FromServices] ICustomerHandler handler) =>
            await handler.CreateAsync(request));

        app.MapPut("/v1/customers/{id}", async (
                [FromRoute] Guid id,
                [FromBody] BugStore.Requests.Customers.Update request,
                [FromServices] ICustomerHandler handler) =>
            await handler.UpdateAsync(id, request));

        app.MapDelete("/v1/customers/{id}", async (
                [FromRoute] Guid id,
                [FromServices] ICustomerHandler handler) =>
            await handler.DeleteAsync(id));
    }
}