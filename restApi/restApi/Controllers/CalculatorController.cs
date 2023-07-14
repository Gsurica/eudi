using Microsoft.AspNetCore.Mvc;

namespace restApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase {

    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger) {
        _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Get(string firstNumber, string secondNumber) {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }
        return BadRequest("Invalid Input!");
    }

    [HttpGet("sub/{firstNumber}/{secondNumber}")]
    public IActionResult GetSub(string firstNumber, string secondNumber) {
        if (firstNumber == null || secondNumber == null) {
            return BadRequest("Input musnt be null!");
        }
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber)) {
            var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
            return Ok(sub.ToString());
        }
        return BadRequest("Invalid Input!");
    }

    [HttpGet("mul/{firstNumber}/{secondNumber}")]
    public IActionResult GetMul(string fistNumber, string secondNumber) {
        return BadRequest("Invalid Input!");
    }

    private static bool IsNumeric(string strNumber) {
        double number;
        bool isNumber = double.TryParse(
            strNumber, System.Globalization.NumberStyles.Any, 
            System.Globalization.NumberFormatInfo.InvariantInfo, 
            out number);
        return isNumber;
    }

    private static decimal ConvertToDecimal(string strNumber) {
        decimal decimalValue;
        if (decimal.TryParse(strNumber, out decimalValue)) {
            return decimalValue;
        }
        return 0;
    }
}
