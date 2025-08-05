using AmountToWords.Lib.Services;

namespace AmountToWords.Lib.Models;

public class DollarsAndCents
{
    public long Dollars { get; }
    public int Cents { get; }
    public bool IsNegative { get; }
    public string Fraction => $"{Cents:D2}/100";
    private List<int>? _threeDigitGroups;
    private readonly IAmountToWordsConverter _converter;

    public DollarsAndCents(decimal amount, IAmountToWordsConverter converter)
    {
        _converter = converter;

        // Round early and uniformly
        var rounded = Math.Round(amount, 2, MidpointRounding.AwayFromZero);
        IsNegative = rounded < 0;

        var absolute = Math.Abs(rounded);
        Dollars = (long)absolute;
        Cents = (int)((absolute - Dollars) * 100);
    }

    // Final word rendering of the amount including fractional formatting
    public override string ToString()
    {
        if (_threeDigitGroups == null)
            _threeDigitGroups = _converter.GetThreeDigitGroups(Dollars);

        var words = _converter.GetMagnitudeWords(_threeDigitGroups);

        var core = string.IsNullOrWhiteSpace(words) ? "zero" : words;
        if (IsNegative) core = "negative " + core;

        return CapitalizeFirst($"{core} and {Fraction} dollars");
    }

    // Basic initial capitalization for sentence formatting
    private static string CapitalizeFirst(string input)
    {
        return string.IsNullOrWhiteSpace(input)
            ? input
            : char.ToUpper(input[0]) + input.Substring(1);
    }
}
