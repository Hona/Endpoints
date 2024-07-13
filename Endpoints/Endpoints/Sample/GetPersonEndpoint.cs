using System.Net.Http;
using Hona.Endpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Sample;

public class GetPersonEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("person",
            (HttpClient client) => client.GetStringAsync("https://jsonplaceholder.typicode.com/users/1"));
    }
}