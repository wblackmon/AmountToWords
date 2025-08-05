using AmountToWords.Lib.Mapping;

namespace AmountToWords.Lib.Services
{
    public class AmountToWordsConverter : IAmountToWordsConverter
    {
        // Holds numeric word mappings (ones, tens, magnitudes, etc.)
        private readonly NumberMaps _numberMaps;

        // Inject maps dependency—keeps things flexible and testable
        public AmountToWordsConverter(NumberMaps numberMaps)
        {
            _numberMaps = numberMaps;
        }

        // Break the number into 3-digit groups (for thousands, millions, etc.)
        public List<int> GetThreeDigitGroups(long number)
        {
            var groups = new List<int>();
            while (number > 0)
            {
                groups.Add((int)(number % 1000)); // isolate next 3 digits
                number /= 1000;
            }
            return groups;
        }

        // Convert a single 3-digit chunk into word form
        public string ConvertThreeDigitGroupToWords(int number)
        {
            if (number == 0) return "";

            int hundred = number / 100;
            int remainder = number % 100;

            var parts = new List<string>();

            // "X hundred"
            if (hundred > 0)
                parts.Add($"{_numberMaps.Ones[hundred]} hundred");

            if (remainder > 0)
            {
                // Handle 1–19 directly
                if (remainder < 20)
                {
                    parts.Add(_numberMaps.Ones[remainder]);
                }
                else
                {
                    int ten = remainder / 10;
                    int digits = remainder % 10;

                    // Handle cases like "twenty" vs. "twenty-three"
                    string twoDigits = digits == 0
                        ? _numberMaps.Tens[ten]
                        : $"{_numberMaps.Tens[ten]}-{_numberMaps.Ones[digits]}";

                    parts.Add(twoDigits);
                }
            }

            return string.Join(" ", parts);
        }

        // Stitch together full magnitude phrase (e.g. "Three Million Two Hundred...")
        public string GetMagnitudeWords(List<int> groups)
        {
            var parts = new List<string>();
            for (int i = 0; i < groups.Count; i++)
            {
                int value = groups[i];
                if (value == 0) continue;

                string words = ConvertThreeDigitGroupToWords(value);
                string magnitude = _numberMaps.Magnitudes[i];

                // Prepend highest magnitude first
                parts.Insert(0, string.IsNullOrWhiteSpace(magnitude)
                    ? words
                    : $"{words} {magnitude}");
            }

            return string.Join(" ", parts).Trim();
        }
    }
}
