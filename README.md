# CampaignBudgetOptimizer

To run this application:

1. Ensure you have .NET SDK installed. You can download it from: [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)
2. Clone the repository to your local machine.
3. Navigate to the project directory.
4. Open a terminal/cmd in the project directory.
5. Run the command: `dotnet run`

### Explanation:

1. **Initialization and User Input:**
   - The program begins by greeting the user.
   - Prompts the user to input essential campaign parameters such as the total budget \( Z \), current ad spend, agency fee percentages, third-party tool fee percentages, and fixed costs.

2. **Initial Setup for Optimization:**
   - Sets an initial guess for the budget of the specific ad we are optimizing.
   - Defines the maximum number of iterations to run the Goal Seek algorithm and the tolerance for convergence.

3. **Goal Seek Function:**
   - The `GoalSeek` function aims to find the budget for the specific ad such that the total budget \( Z \) is maintained.
   - Uses a binary search approach by defining initial bounds (`low = 0`, `high = Z`).
   - Iteratively adjusts these bounds by computing the midpoint and evaluating the total campaign cost.
   - If the computed total cost is within the acceptable tolerance of the target \( Z \), it returns the midpoint value as the optimal budget.
   - If the total cost is less than \( Z \), it adjusts the lower bound; otherwise, it adjusts the upper bound.

4. **Convergence Check and Output:**
   - If the function does not converge within the maximum iterations, it returns -1, indicating failure to find a solution within the constraints.
   - Displays the optimal ad budget to the user or indicates if the function did not converge.
