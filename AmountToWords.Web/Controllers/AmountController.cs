using AmountToWords.Lib.Models;
using AmountToWords.Lib.Services;
using AmountToWords.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace AmountToWords.Web.Controllers;

public class AmountController : Controller
{
    // Injected converter responsible for numeric-to-word transformation
    private readonly IAmountToWordsConverter _converter;

    // Constructor wiring up the converter dependency
    public AmountController(IAmountToWordsConverter converter)
    {
        _converter = converter;
    }

    [HttpPost]
    public IActionResult Convert(AmountViewModel model)
    {
        // Validate the incoming amount model before processing
        if (ModelState.IsValid)
        {
            // Parse into structured dollars and cents using shared logic
            var dollarsAndCents = new DollarsAndCents(model.Amount, _converter);

            // Generate word output from the parsed structure
            model.AmountWords = dollarsAndCents.ToString();
        }

        // Always return to Index view, populated or not
        return View("Index", model);
    }

    [HttpGet]
    public IActionResult Index()
    {
        // Initialize empty view model on GET
        return View(new AmountViewModel());
    }
}
