using Microsoft.AspNetCore.Mvc;

namespace TyringHusky.Controllers;

[ApiController]
public class BasicController : ControllerBase
{
    public IActionResult GetHealth()
    {
        return Ok("Good")
    }
}