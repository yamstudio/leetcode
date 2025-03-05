/*
 * @lc app=leetcode id=1414 lang=java
 *
 * [1414] Find the Minimum Number of Fibonacci Numbers Whose Sum Is K
 */

// @lc code=start
class Solution {
    public int findMinFibonacciNumbers(int k) {
        if (k <= 1) {
            return k;
        }
        int a = 1, b = 1;
        while (b <= k) {
            int n = a + b;
            a = b;
            b = n;
        }
        return 1 + findMinFibonacciNumbers(k - a);
    }
}
// @lc code=end

