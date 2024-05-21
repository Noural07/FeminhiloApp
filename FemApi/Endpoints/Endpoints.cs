using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using FemApi.Services;
using System;
using System.Threading.Tasks;
using Fem.Shared.Data;

namespace FemApi.Endpoints
{
    public static class Endpoints
    {
        public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/api/items", async (ItemService itemService) =>
            {
                return await itemService.GetItemsAsync();
            })
            .WithName("GetItems")
            .WithTags("Items");

            // POST: /api/items
            app.MapPost("/api/items", async (ItemService itemService, ItemD newItem) =>
            {
                var createdItem = await itemService.PostItemAsync(newItem);
                return Results.Created($"/api/items/{createdItem.id}", createdItem);
            })
            .WithName("PostItem")
            .WithTags("Items");

            // DELETE: /api/items/{id}
            app.MapDelete("/api/items/{id:int}", async (ItemService itemService, int id) =>
            {
                var success = await itemService.DeleteItemAsync(id);
                return success ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteItem")
            .WithTags("Items");

            return app;
        }
    }
}
