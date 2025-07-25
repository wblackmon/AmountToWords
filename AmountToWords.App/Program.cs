// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, Convert Amount to Words!");

/*
Problem: Amount To Words
Write some code that will accept an amount and convert it to the appropriate string representation.

Example:
Convert 2523.04 to “Two thousand five hundred twenty-three and 04/100 dollars”.

Input: decimal amount
Output: string of words
Constraints:
Valid input range between $0.00 and $1,000,000,000
Two decimal precision (round if necessary)
No negative amounts
Output format - words and fraction of a dollar.

Edge cases:
0.00 -> "Zero and 00/100 dollars"
0.01 -> "Zero and 01/100 dollars"
10.0 -> "Ten and 0/100 dollars"
1000000000.00 -> Max allowed value
0.4, 98.5, 0.035 -> round to "50/100 dollars", "Ninety Eight and 50/100",  round to "04/100 dollars"
-17.00 -> negative not allowed
2523.0457 -> round to 2523.05
*/
var samples = new[]
{
    0.00m, 0.01m, 0.50m, 0.99m,
    1.00m, 12.00m, 99.99m, 100.00m,
    215.48m, 999.99m, 1000.00m,
    4230.75m, 12345.67m, 25001.00m,
    87654.32m, 100000.00m, 654321.00m,
    1000000.00m, 2505010.23m,
    9999999.99m, 75500000.00m,
    999000000.99m
};

foreach (var amount in samples)
{
    var parts = new DollarsAndCents(amount);
    Console.WriteLine($"Amount: ${amount:N2}");
    Console.WriteLine($"Words: {parts.ToFullAmountString()}");
    Console.WriteLine(new string('-', 40));
}



