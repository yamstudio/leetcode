/*
 * @lc app=leetcode id=1362 lang=java
 *
 * [1362] Closest Divisors
 */

// @lc code=start
class Solution {
    public int[] closestDivisors(int num) {
        int n1 = num + 1, n2 = num + 2;
        for (int i = (int)Math.sqrt(n2); i >= 1; --i) {
            if (n1 % i == 0) {
                return new int[] { i, n1 / i };
            }
            if (n2 % i == 0) {
                return new int[] { i, n2 / i };
            }
        }
        return new int[0];
    }
}
// @lc code=end

