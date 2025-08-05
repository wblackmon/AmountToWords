namespace AmountToWords.Lib.Mapping
{
    public class NumberMaps
    {
        // 0–19 mapped directly to their word representations
        public Dictionary<int, string> Ones { get; } = new Dictionary<int, string>
        {
            [0] = "zero",
            [1] = "one",
            [2] = "two",
            [3] = "three",
            [4] = "four",
            [5] = "five",
            [6] = "six",
            [7] = "seven",
            [8] = "eight",
            [9] = "nine",
            [10] = "ten",
            [11] = "eleven",
            [12] = "twelve",
            [13] = "thirteen",
            [14] = "fourteen",
            [15] = "fifteen",
            [16] = "sixteen",
            [17] = "seventeen",
            [18] = "eighteen",
            [19] = "nineteen"
        };

        // Multiples of ten from 20–90
        public Dictionary<int, string> Tens { get; } = new Dictionary<int, string>
        {
            [2] = "twenty",
            [3] = "thirty",
            [4] = "forty",
            [5] = "fifty",
            [6] = "sixty",
            [7] = "seventy",
            [8] = "eighty",
            [9] = "ninety"
        };

        // Magnitude terms based on 3-digit group position
        public Dictionary<int, string> Magnitudes { get; } = new Dictionary<int, string>
        {
            [0] = "",              // Base (e.g., hundreds)
            [1] = "thousand",
            [2] = "million",
            [3] = "billion",
            [4] = "trillion"       // Extendable if needed
        };
    }
}
