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
        if (VerifyNumbers(firstNumber, secondNumber)) {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return Ok(sum.ToString());
        }
        return BadRequest("Invalid Input!");
    }

    [HttpGet("sub/{firstNumber}/{secondNumber}")]
    public IActionResult GetSub(string firstNumber, string secondNumber) {
        if (VerifyNumbers(firstNumber, secondNumber)) {
            var sub = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
            return Ok(sub.ToString());
        }
        return BadRequest("Invalid Input!");
    }

    [HttpGet("mul/{firstNumber}/{secondNumber}")]
    public IActionResult GetMul(string firstNumber, string secondNumber) {
        if (VerifyNumbers(firstNumber, secondNumber)) {
            var mult = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
            return Ok(mult.ToString());
        }
        return BadRequest("Invalid Input!");
    }

    [HttpGet("div/{firstNumber}/{secondNumber}")]
    public IActionResult GetDiv(string firstNumber, string secondNumber) {
        if (!VerifyZero(firstNumber) || !VerifyZero(secondNumber)) {
            return BadRequest("Cannot divide a number with zero!");
        }
        if (VerifyNumbers(firstNumber, secondNumber)) {
            var div = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
            return Ok(div.ToString());           
        }
        return BadRequest("Invalid input!");
    }

    [HttpGet("pow/{firstNumber}/{secondNumber}")]
    public IActionResult GetPow(string firstNumber, string secondNumber) {
        if (VerifyNumbers(firstNumber, secondNumber)) {
            var pow = Math.Pow(ConvertToDouble(firstNumber), ConvertToDouble(secondNumber));
            return Ok(pow.ToString());
        }
        return BadRequest("Invalid Input!");    
    }

    [HttpGet("sqr/{squareRoot}")]
    public IActionResult GetSqr(string squareRoot) {
        if (VerifyNumber(squareRoot)) {
            var sqr = Math.Sqrt(ConvertToDouble(squareRoot));
            return Ok(sqr.ToString());
        }
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

    private static double ConvertToDouble(string strNumber) {
        double doubleNumber;
        if (double.TryParse(strNumber, out doubleNumber)) {
            return doubleNumber;
        }
        return 0;
    }

    private static bool VerifyZero(string strNumber) {
        var convertedNumber = ConvertToDecimal(strNumber);
        if (convertedNumber != 0) {
            return true;
        }
        return false;
    }

    private static bool VerifyNumbers(string strNumber1, string strNumber2) {
        if (IsNumeric(strNumber1) && IsNumeric(strNumber2)) {
            return true;
        }
        return false;
    }

    private static bool VerifyNumber(string number) {
        if (IsNumeric(number)) {
            return true;
        }
        return false;
    }
}
