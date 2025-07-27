namespace AmountToWords.Lib.Mapping;

public class NumberMaps 
{
    public readonly string[] Ones = {
        "", "one", "two", "three", "four", "five", "six",
        "seven", "eight", "nine", "ten", "eleven", "twelve",
        "thirteen", "fourteen", "fifteen", "sixteen",
        "seventeen", "eighteen", "nineteen"
    };

    public readonly string[] Tens = {
        "", "", "twenty", "thirty", "forty", "fifty",
        "sixty", "seventy", "eighty", "ninety"
    };

    public readonly string[] Magnitudes = {
        "", "thousand", "million", "billion", "trillion"
        // Expand as needed
    };
}
