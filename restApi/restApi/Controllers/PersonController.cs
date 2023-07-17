using Microsoft.AspNetCore.Mvc;

namespace restApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase {

    private readonly ILogger<PersonController> _logger;

    public PersonController(ILogger<PersonController> logger) {
        _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Get(string firstNumber, string secondNumber) {
        return BadRequest("Invalid input!");
    }
}
