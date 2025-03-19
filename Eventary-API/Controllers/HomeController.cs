using Microsoft.AspNetCore.Mvc;

[Route("/")]
[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { message = "Welcome to Eventary API!" });
    }
}
