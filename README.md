# Amount To Words

A .NET 8 solution for converting decimal currency amounts into their English word representation. Includes a Razor Pages web app and a console app.

## Problem

Write code that accepts a decimal amount and converts it to the appropriate string representation.

**Example:**  
`2523.04` → `Two thousand five hundred twenty-three and 04/100 dollars`

## Constraints

- **Input:** decimal amount
- **Output:** string of words
- Valid input range: `$0.00` to `$1,000,000,000`
- Two decimal precision (rounded if necessary)
- No negative amounts
- Output format: words and fraction of a dollar

## Edge Cases

| Input         | Output                                         |
|---------------|------------------------------------------------|
| 0.00          | Zero and 00/100 dollars                        |
| 0.01          | Zero and 01/100 dollars                        |
| 10.0          | Ten and 00/100 dollars                         |
| 1000000000.00 | One billion and 00/100 dollars                 |
| 0.4           | Zero and 40/100 dollars                        |
| 98.5          | Ninety-eight and 50/100 dollars                |
| 0.035         | Zero and 04/100 dollars                        |
| -17.00        | (invalid, negative not allowed)                |
| 2523.0457     | Two thousand five hundred twenty-three and 05/100 dollars |

## Project Structure

- **AmountToWords.App**: Console application for sample conversions.
- **AmountToWords.Web**: Razor Pages web app for interactive conversion.
- **AmountToWords.Lib**: Core library with conversion logic.
- **AmountToWords.Tests**: Unit and integration tests.

## Getting Started

By default, the app will be available at [https://localhost:5001](https://localhost:5001) or the port shown in your console.

## Web App Usage

1. **Start the Web App**

   Run the following command in your project directory:

2. **Convert an Amount**

   - In your browser, navigate to the running web app.
   - Enter a decimal amount (e.g., `2523.04`) in the **Decimal Amount** field.
   - Click the **Convert** button.
   - The amount in words will be displayed below, for example:  
     `Two thousand five hundred twenty-three and 04/100 dollars`

3. **Validation**

   - Only amounts between `$0.00` and `$1,000,000,000` are accepted.
   - Negative values and invalid input will show validation errors.
   - The result updates each time you submit a new amount.

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Build and Run (Console)