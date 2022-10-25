using Microsoft.AspNetCore.Mvc;

namespace LiveSync.Central.Legacy.Controllers;

[ApiController]
[Route("[controller]")]
public class VisitController : ControllerBase
{
    // GET
    public IActionResult Index(int? siteCode)
    {
        return Ok(100);
    }
}