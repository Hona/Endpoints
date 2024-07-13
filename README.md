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