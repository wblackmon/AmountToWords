using AmountToWords.Lib.Mapping;

namespace AmountToWords.Lib.Services
{
    public class AmountToWordsConverter : IAmountToWordsConverter
    {
        private readonly NumberMaps _numberMaps;

        public AmountToWordsConverter(NumberMaps numberMaps)
        {
            _numberMaps = numberMaps;
        }

        public AmountToWordsConverter()
        {
        }

        public List<int> GetThreeDigitGroups(long number)
        {
            var groups = new List<int>();
            while (number > 0)
            {
                groups.Add((int)(number % 1000));
                number /= 1000;
            }
            return groups;
        }

        public string ConvertThreeDigitGroupToWords(int number)
        {
            if (number == 0) return "";

            int hundred = number / 100;
            int remainder = number % 100;

            var parts = new List<string>();

            if (hundred > 0)
                parts.Add($"{_numberMaps.Ones[hundred]} hundred");

            if (remainder > 0)
            {
                if (remainder < 20)
                {
                    parts.Add(_numberMaps.Ones[remainder]);
                }
                else
                {
                    int ten = remainder / 10;
                    int digits = remainder % 10;
                    string twoDigits = digits == 0 ? _numberMaps.Tens[ten] : $"{_numberMaps.Tens[ten]}-{_numberMaps.Ones[digits]}";
                    parts.Add(twoDigits);
                }
            }

            return string.Join(" ", parts);
        }

        public string GetMagnitudeWords(List<int> groups)
        {
            var parts = new List<string>();
            for (int i = 0; i < groups.Count; i++)
            {
                int value = groups[i];
                if (value == 0) continue;

                string words = ConvertThreeDigitGroupToWords(value);
                string magnitude = _numberMaps.Magnitudes[i];

                parts.Insert(0, string.IsNullOrWhiteSpace(magnitude) ? words : $"{words} {magnitude}");
            }

            return string.Join(" ", parts).Trim();
        }
    }
}
