using AmountToWords.Lib.Services;

namespace AmountToWords.Lib.Models;

public class DollarsAndCents
{
    public long Dollars { get; }
    public int Cents { get; }
    public string Fraction => $"{Cents:D2}/100";

    private List<int>? _threeDigitGroups;
    private readonly AmountToWordsConverter _converter;

    public DollarsAndCents(decimal amount)
    {
        _converter = new AmountToWordsConverter();
        Dollars = (long)Math.Floor(amount);
        Cents = (int)((amount - Dollars) * 100);
    }

    public List<int> GetGroups()
    {
        if (_threeDigitGroups == null)
            _threeDigitGroups = _converter.GetThreeDigitGroups(Dollars);
        return _threeDigitGroups;
    }

    public override string ToString()
    {
        string words = _converter.GetMagnitudeWords(GetGroups());
        return string.IsNullOrWhiteSpace(words) ? "zero" : words;
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
