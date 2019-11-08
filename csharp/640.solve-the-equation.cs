/*
 * @lc app=leetcode id=640 lang=csharp
 *
 * [640] Solve the Equation
 */

// @lc code=start
public class Solution {
    public string SolveEquation(string equation) {
        int a = 0, b = 0, d = 1, n = equation.Length, j = 0;
        for (int i = 0; i < n; ++i) {
            char curr = equation[i];
            if (curr == '+' || curr == '-') {
                if (i > j) {
                    b += d * int.Parse(equation.Substring(j, i - j));
                }
                j = i;
            } else if (curr == 'x') {
                if (i == j || equation[i - 1] == '+') {
                    a += d;
                } else if (equation[i - 1] == '-') {
                    a -= d;
                } else {
                    a += d * int.Parse(equation.Substring(j, i - j));
                }
                j = i + 1;
            } else if (curr == '=') {
                if (i > j) {
                    b += int.Parse(equation.Substring(j, i - j));
                }
                j = i + 1;
                d = -1;
            }
        }
        if (n > j) {
            b -= int.Parse(equation.Substring(j));
        }
        if (a == 0) {
            if (b == 0) {
                return "Infinite solutions";
            }
            return "No solution";
        }
        return $"x={-b / a}";
    }
}
// @lc code=end

