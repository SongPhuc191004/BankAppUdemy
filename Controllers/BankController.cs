using BankAppUdemy.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankAppUdemy.Controllers
{
    public class BankController : Controller
    {
        [Route("/")]
        public IActionResult Home()
        {
            return Content("<h1>Welcome to the Bank App!</h1>", "text/html");
        }

        [Route("/account-details")]
        public JsonResult Account()
        {
            Account account = new Account
            {
                accountNumber = 1001,
                accountHolderName = "John Doe",
                currentBalance = 5000
            };
            return Json(account);
        }

        [Route("/account-statement")]
        public IActionResult Statement()
        {
            return File("DummyPDF.pdf", "application/pdf");
        }

        [Route("/get-current-balance/{accountNumber:int?}")]
        public IActionResult GetCurrentBalance()
        {
            object accountNumber = RouteData.Values["accountNumber"];
            if(accountNumber == null)
            {
                return NotFound("Account number not provided");
            }
            int accountNumberInt = Convert.ToInt32(accountNumber);
            if(accountNumberInt != 1001)
            {
                return BadRequest("Account Number should be 1001");
            }
            return Content("<h2>The current balance is $5000</h2>", "text/html");
        }
    }
}
