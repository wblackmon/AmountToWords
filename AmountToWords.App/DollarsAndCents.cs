using System;

public class DollarsAndCents
{
    public static bool IsNegative { get; set; }
    public long Dollars { get; }
    public int Cents { get; }
    public string Fraction => $"{Cents:D2}/100";

    private List<int>? _threeDigitGroups;

    public DollarsAndCents(decimal amount)
    {
        amount = Math.Round(amount, 2, MidpointRounding.AwayFromZero);
        IsNegative = amount < 0;
        amount = Math.Abs(amount);
        Dollars = (long)Math.Floor(amount);
        Cents = (int)((amount - Dollars) * 100);
    }

    public List<int> GetGroups()
    {
        if (_threeDigitGroups == null)
            _threeDigitGroups = AmountToWordsConverter.GetThreeDigitGroups(Dollars);
        return _threeDigitGroups;
    }

    public override string ToString()
    {
        var words = AmountToWordsConverter.GetMagnitudeWords(GetGroups());

        // Fall back to "zero" if no words were generated
        var core = string.IsNullOrWhiteSpace(words) ? "zero" : words;

        // Return full output with initial cap and fractional cents
        var result = $"{core} and {Fraction} dollars";
        if (!IsNegative)
        {
            result = CapitalizeFirst(result);
        }
        return IsNegative ? $"Negative {result}" : result;
    }

    public string ToFullAmountString()
    {
        string core = ToString();
        return CapitalizeFirst($"{core} and {Fraction} dollars");
    }

    private static string CapitalizeFirst(string input)
    {
        return string.IsNullOrWhiteSpace(input)
            ? input
            : char.ToUpper(input[0]) + input.Substring(1);
    }
}
