
namespace AmountToWords.Lib.Services;
public interface IAmountToWordsConverter
{
    string ConvertThreeDigitGroupToWords(int number);
    string GetMagnitudeWords(List<int> groups);
    List<int> GetThreeDigitGroups(long number);
}