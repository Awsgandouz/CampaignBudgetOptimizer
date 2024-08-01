using System;

class CampaignBudgetOptimizer
{
    static void Main(string[] args)
    {
        // Welcome message for the user
        Console.WriteLine("Welcome to Campaign Budget Optimizer!");

        // Prompt user to input total campaign budget
        Console.Write("Enter total campaign budget (Z): ");
        double Z = Convert.ToDouble(Console.ReadLine());

        // Prompt user to input current total ad spend for other ads
        Console.Write("Enter current total ad spend for other ads: ");
        double currentAdSpend = Convert.ToDouble(Console.ReadLine());

        // Prompt user to input agency fee percentage
        Console.Write("Enter agency fee percentage (Y1): ");
        double Y1 = Convert.ToDouble(Console.ReadLine());

        // Prompt user to input third-party fee percentage
        Console.Write("Enter third-party fee percentage (Y2): ");
        double Y2 = Convert.ToDouble(Console.ReadLine());

        // Prompt user to input fixed cost for agency hours
        Console.Write("Enter fixed cost for agency hours (HOURS): ");
        double HOURS = Convert.ToDouble(Console.ReadLine());

        // Prompt user to input budget for ads created with third-party tools
        Console.Write("Enter budget for ads created with third-party tools (X1 + X2 + X4): ");
        double thirdPartyAdSpend = Convert.ToDouble(Console.ReadLine());

        // Initial guess value for the budget of the specific ad we are optimizing
        double initialGuess = Z / 2;
        // Maximum number of iterations to find the solution
        double maxIterations = 1000;
        // Tolerance level for convergence of the algorithm
        double tolerance = 0.01;

        // Run the Goal Seek function to find the optimal budget for the specific ad
        double adBudget = GoalSeek(Z, currentAdSpend, Y1, Y2, HOURS, thirdPartyAdSpend, initialGuess, maxIterations, tolerance);
        
        // Check if the Goal Seek function converged to a solution
        if (adBudget == -1)
            Console.WriteLine("The function did not converge.");
        else
            Console.WriteLine("The optimal budget for the specific ad is: " + adBudget);
    }

    static double GoalSeek(double Z, double currentAdSpend, double Y1, double Y2, double HOURS, double thirdPartyAdSpend, double initialGuess, double maxIterations, double tolerance)
    {
        // Define the initial low and high bounds for the budget
        double low = 0;
        double high = Z;
        double mid = 0;
        
        // Perform a binary search to find the value that meets the desired total budget
        for (int i = 0; i < maxIterations; i++)
        {
            // Calculate the midpoint of the current bounds
            mid = (low + high) / 2;
            // Calculate current total ad spend including the midpoint value
            double X = currentAdSpend + mid;
            
            // Calculate the total cost based on the given formula
            double totalCost = X + Z * X * Y1 + Y2 * thirdPartyAdSpend + HOURS;
            
            // Check if the total cost is within the acceptable tolerance of the target budget Z
            if (Math.Abs(totalCost - Z) <= tolerance)
                return mid;  // Return the midpoint as the optimal budget
            
            // Adjust the bounds based on whether the total cost is less than or greater than the target budget
            if (totalCost < Z)
                low = mid;   // Increase the lower bound
            else
                high = mid;  // Decrease the upper bound
        }
        
        // If the function does not converge within the maximum iterations, return -1
        return -1;
    }
}
