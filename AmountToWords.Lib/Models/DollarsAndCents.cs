using AmountToWords.Lib.Services;

namespace AmountToWords.Lib.Models;

public class DollarsAndCents
{
    // Truncate whole dollar portion of the amount
    public long Dollars { get; }

    // Extract cent portion from the fractional remainder
    public int Cents { get; }

    // Format cents as a fraction (e.g. "45/100")
    public string Fraction => $"{Cents:D2}/100";

    // Cached groupings of digits (used for magnitude translation)
    private List<int>? _threeDigitGroups;

    // Injected converter responsible for numeric-to-words translation
    private readonly IAmountToWordsConverter _converter;

    // Constructor splits the incoming amount into dollars and cents
    public DollarsAndCents(decimal amount, IAmountToWordsConverter converter)
    {
        _converter = converter;
        Dollars = (long)Math.Floor(amount);
        Cents = (int)((amount - Dollars) * 100);
    }

    // Lazily compute digit groups once for reuse across translation calls
    public List<int> GetGroups()
    {
        if (_threeDigitGroups == null)
            _threeDigitGroups = _converter.GetThreeDigitGroups(Dollars);

        return _threeDigitGroups;
    }

    // Final word rendering of the amount including fractional formatting
    public override string ToString()
    {
        var words = _converter.GetMagnitudeWords(GetGroups());

        // Fall backwqws to "zero" if no words were generated
        var core = string.IsNullOrWhiteSpace(words) ? "zero" : words;

        // Return full output with initial cap and fractional cents
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
