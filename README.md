## Web App Usage

1. **Start the Web App**

   - Run the following command in your project directory:

     ```bash
     dotnet run --project AmountToWords.Web
     ```

   - *Or start the web app in Visual Studio by hitting `Ctrl + F5`.*

2. **Navigate to the Conversion Page**

   - Click the **Amount** link in the navigation bar at the top of the page,  
     *or enter* [https://localhost:7159/amount](https://localhost:7159/amount) *directly into your browser.*

3. **Convert an Amount**

   - Enter a decimal amount (e.g., `2523.04`) in the **Decimal Amount** field.
   - Click the **Convert** button.
   - The amount in words will be displayed below, for example:  
     `Two thousand five hundred twenty-three and 04/100 dollars`

4. **Validation**

   - Only amounts between `$0.00` and `$1,000,000,000` are accepted.
   - Negative values and invalid input will show validation errors.
   - The result updates each time you submit a new amount.

---

*Created by Wayne Blackmon*