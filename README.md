# Endpoints
A minimal source generator that decouples endpoint definition from wiring up to the host

## Installation

Add the `Hona.Endpoints` NuGet package.

In your application, implement the `IEndpoint` interface and define your endpoints.

```csharp
public class Adder : IEndpoint
{
    public static void Map(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/add", (int a, int b) => (a + b).ToString());
    }
}
```

Finally, one line to wire up all IEndpoint implementations:

```csharp
app.MapEndpoints();
```

That's it.

## Extensions

This GitHub repo also contains the Mediator extensions for Hona.Endpoints.

Add the `Hona.Endpoints.Extensions.Mediator` NuGet package.

With the Mediator extensions, you can easily define endpoints that use REPR over Mediator.

```csharp
endpoints
    .MapCommandPost<Request, Response>("/todos")
    .WithTags("Todos")
    .WithDescription("Create a new todo, somehow.")
    .AllowAnonymous();
```

without the extensions, you would have to do this:

```csharp
endpoints
    .MapPost(
        "/todos",
        (
            Mediator.Mediator mediator,
            CancellationToken cancellationToken,
            [FromBody] Request request
        ) => mediator.Send(request, cancellationToken)
    )
    .Produces<Response>((int)HttpStatusCode.Created)
    .WithTags("Todos")
    .WithDescription("Create a new todo, somehow.")
    .AllowAnonymous();
```