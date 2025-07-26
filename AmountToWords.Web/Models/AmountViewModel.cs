using System.ComponentModel.DataAnnotations;

namespace AmountToWords.Web.Models
{
    public class AmountViewModel
    {
        [Required(ErrorMessage = "Please enter an amount")]
        public decimal? Amount { get; set; } = null;
        public  string? AmountWords { get; set; }
    }
}
