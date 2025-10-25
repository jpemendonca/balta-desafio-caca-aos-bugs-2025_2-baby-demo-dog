﻿using BugStore.Handlers.Order;
using BugStore.Requests.Orders;
using Microsoft.AspNetCore.Mvc;

namespace BugStore.Endpoints.Order;

public static class OrderEndpoints
{
    public static void MapOrderEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/v1/orders");

        group.WithTags("Orders");

        group.MapGet("/", async (
                [FromServices] IOrderHandle handler) =>
            await handler.GetAllAsync());

        group.MapGet("/{id}", async (
                [FromRoute] Guid id,
                [FromServices] IOrderHandle handler) =>
            await handler.GetByIdAsync(id));

        group.MapPost("/", async (
                [FromBody] BugStore.Requests.Orders.Create request,
                [FromServices] IOrderHandle handler) =>
            await handler.CreateAsync(request));

        group.MapDelete("/{id}", async (
                [FromRoute] Guid id,
                [FromServices] IOrderHandle handler) =>
            await handler.DeleteAsync(id));
    }
}