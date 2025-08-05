using System.ComponentModel.DataAnnotations;

namespace AmountToWords.Web.Models
{
    public class AmountViewModel
    {
        [Required(ErrorMessage = "Please enter an amount")]
        [Range(typeof(decimal), "-9999999999.99", "9999999999.99", ErrorMessage = "Amount must be greater than zero")]
        public decimal Amount { get; set; }

        public string? AmountWords { get; set; }

    }
}
