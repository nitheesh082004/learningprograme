using System;

namespace FinancialForecasting
{
    class Program
    {
        // Step 2 & 3: Recursive method to calculate future value
        static double CalculateFutureValue(double initialValue, double growthRate, int years)
        {
            // Base case: no growth after 0 years
            if (years == 0)
                return initialValue;

            // Recursive case: apply growth rate to previous year's value
            double previousValue = CalculateFutureValue(initialValue, growthRate, years - 1);
            return previousValue + (previousValue * growthRate);
        }

        static void Main(string[] args)
        {
            // Sample input values
            double startingValue = 10000;    // Initial investment
            double annualGrowthRate = 0.07;  // 7% growth rate
            int totalYears = 5;              // Forecast for 5 years

            // Calculate future value using recursion
            double futureValue = CalculateFutureValue(startingValue, annualGrowthRate, totalYears);

            Console.WriteLine($"Future Value after {totalYears} years: ₹{futureValue:F2}");
            Console.ReadLine();
        }
    }
}
