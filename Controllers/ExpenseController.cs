using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoenixLifeApi.Databases;
using PhoenixLifeApi.Models;

namespace PhoenixLifeApi.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly PhoenixContext phoenixContext;
        public ExpenseController(PhoenixContext phoenixContext)
        {
            this.phoenixContext = phoenixContext;
        }

        [HttpGet]
        [Route("/Expenses")]
        public async Task<ActionResult> GetExpenses()
        {
            var Expenses = await phoenixContext.Expenses.Select(x => x).ToListAsync();
            if(Expenses == null)
            {
                return NotFound();
            }
            return Ok(Expenses);
        }

        [HttpPost]
        [Route("/Expenses/Add")]
        public async Task<ActionResult> AddExpense([FromBody] Expense expense)
        {
            expense.Date = DateTime.Now.ToString("MM-dd-yyyy");
            phoenixContext.Expenses.Add(expense);
            await phoenixContext.SaveChangesAsync();
            return Ok();
        }


    }
}
