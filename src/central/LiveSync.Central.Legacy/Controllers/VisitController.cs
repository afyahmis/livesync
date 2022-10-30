using System.Collections.Generic;
using LiveSync.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LiveSync.Central.Legacy.Controllers;

[ApiController]
[Route("[controller]")]
public class VisitController : ControllerBase
{
    [HttpPost]
    public IActionResult Index(List<Visit> visits)
    {
        return Ok(visits.Count);
    }
}
