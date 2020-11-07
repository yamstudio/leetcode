/*
 * @lc app=leetcode id=1414 lang=csharp
 *
 * [1414] Find the Minimum Number of Fibonacci Numbers Whose Sum Is K
 */

// @lc code=start
public class Solution {
    public int FindMinFibonacciNumbers(int k) {
        if (k < 2) {
            return k;
        }
        int a = 1, b = 1;
        while (b <= k) {
            int nb = a + b;
            a = b;
            b = nb;
        }
        return 1 + FindMinFibonacciNumbers(k - a);
    }
}
// @lc code=end

