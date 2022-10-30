using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcLiveSyncClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace LiveSync.Client.Controllers;

[ApiController]
[Route("[controller]")]
public class UploadController : ControllerBase
{
    private readonly ILogger<GreeterController> _logger;
    private readonly GrpcChannel channel;
    private readonly ApplicationDbContext _context;
    private readonly RestClient _restClient;
    private readonly HttpClient _httpClient;

    public UploadController(ILogger<GreeterController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
        channel=GrpcChannel.ForAddress("http://localhost:5193");
        _restClient = new RestClient("http://localhost:5050");
        _httpClient = new HttpClient();
    }
    
    [HttpPost]
    public  IActionResult Greet(string name)
    {
        var client = new Greeter.GreeterClient(channel);
        
        var reply = client.SayHello(
            new HelloRequest { Name = name });
        return Ok($"{reply}");
    }

    [HttpGet]
    public async Task<IActionResult> GetVisits(string? site)
    {
        var visits =  _context.Visits;
        if(string.IsNullOrWhiteSpace(site))
            return Ok(await visits.Take(10).ToListAsync());

        return Ok(await visits.Where(x => x.SiteCode == site).ToListAsync());
    }
    
    [HttpPost("Legacy")]
    public async Task<IActionResult> SendVisits(string? site)
    {
        var visits = await Read(site);
        var w = Stopwatch.StartNew();
        var res = await _httpClient.PostAsync("http://localhost:5050/visit",
            new StringContent(JsonSerializer.Serialize(visits)));
        w.Stop();
        return Ok($"Received:{res} , Legacy took {w.Elapsed}");
    }
    private async Task<List<ClinicalVisit>> Read(string? site)
    {
        var visits =  _context.Visits;
        if (string.IsNullOrWhiteSpace(site))
            return await visits.Take(10).ToListAsync();
        
        return await visits.Where(x => x.SiteCode == site).ToListAsync();
    }
}

internal interface IHttpClient
{
}
