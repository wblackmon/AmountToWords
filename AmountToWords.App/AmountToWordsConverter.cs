public static class AmountToWordsConverter
{
    public static List<int> GetThreeDigitGroups(long number)
    {
        var groups = new List<int>();
        while (number > 0)
        {
            groups.Add((int)(number % 1000));
            number /= 1000;
        }
        return groups;
    }

    public static string ConvertThreeDigitGroupToWords(int number)
    {
        if (number == 0) return "";


        int hundred = number / 100;
        int remainder = number % 100;

        var parts = new List<string>();

        if (hundred > 0)
            parts.Add($"{NumberMaps.Ones[hundred]} hundred");

        if (remainder > 0)
        {
            if (remainder < 20)
            {
                parts.Add(NumberMaps.Ones[remainder]);
            }
            else
            {
                int ten = remainder / 10;
                int digits = remainder % 10;
                string twoDigits = digits == 0 ? NumberMaps.Tens[ten] : $"{NumberMaps.Tens[ten]}-{NumberMaps.Ones[digits]}";
                parts.Add(twoDigits);
            }
        }

        return string.Join(" ", parts);
    }

    public static string GetMagnitudeWords(List<int> groups)
    {
        var parts = new List<string>();
        for (int i = 0; i < groups.Count; i++)
        {
            int value = groups[i];
            if (value == 0) continue;

            string words = ConvertThreeDigitGroupToWords(value);
            string magnitude = NumberMaps.Magnitudes[i];

            parts.Insert(0, string.IsNullOrWhiteSpace(magnitude) ? words : $"{words} {magnitude}");
        }

        return string.Join(" ", parts).Trim();
    }
}

public static class NumberMaps
{
    public static readonly string[] Ones = {
        "", "one", "two", "three", "four", "five", "six",
        "seven", "eight", "nine", "ten", "eleven", "twelve",
        "thirteen", "fourteen", "fifteen", "sixteen",
        "seventeen", "eighteen", "nineteen"
    };

    public static readonly string[] Tens = {
        "", "", "twenty", "thirty", "forty", "fifty",
        "sixty", "seventy", "eighty", "ninety"
    };

    public static readonly string[] Magnitudes = {
        "", "thousand", "million", "billion", "trillion"
        // Expand as needed
    };
}
