using AmountToWords.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmountToWords.Web.Controllers
{
    public class AmountController : Controller
    {
        [HttpPost]
        public IActionResult Convert(AmountViewModel model)
        {
            if (ModelState.IsValid)
            {
                //model.AmountWords = NumberWords.ConvertAmountToWords(model.Amount);
            }

            return View("Index", model);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new AmountViewModel());
        }
    }
}
