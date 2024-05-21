using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using FemApi.Services;
using System;
using System.Threading.Tasks;

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

            return app;
        }
    }
}
