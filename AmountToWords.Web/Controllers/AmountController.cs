using AmountToWords.Lib.Models;
using AmountToWords.Lib.Services;
using AmountToWords.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmountToWords.Web.Controllers;

public class AmountController : Controller
{
    private readonly IAmountToWordsConverter _converter;

    public AmountController(IAmountToWordsConverter converter)
    {
        _converter = converter;
    }

    [HttpPost]
    public IActionResult Convert(AmountViewModel model)
    {
        if (ModelState.IsValid)
        {
            var dollarsAndCents = new DollarsAndCents(model.Amount, _converter);
            model.AmountWords = dollarsAndCents.ToString();
        }

        return View("Index", model);
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(new AmountViewModel());
    }
}
