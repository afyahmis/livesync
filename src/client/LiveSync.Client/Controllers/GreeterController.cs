using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using GrpcLiveSyncClient;
using Microsoft.Extensions.Logging;

namespace LiveSync.Client.Controllers;

[ApiController]
[Route("[controller]")]
public class GreeterController : ControllerBase
{
    private readonly ILogger<GreeterController> _logger;
    private readonly GrpcChannel channel;

    public GreeterController(ILogger<GreeterController> logger)
    {
        _logger = logger;
        channel=GrpcChannel.ForAddress("http://localhost:5193");
    }
    
    [HttpPost]
    public  IActionResult Greet(string name)
    {
        var client = new Greeter.GreeterClient(channel);
        
        var reply = client.SayHello(
            new HelloRequest { Name = name });
        return Ok($"{reply}");
    }
}
