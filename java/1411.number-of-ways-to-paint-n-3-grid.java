/*
 * @lc app=leetcode id=1411 lang=java
 *
 * [1411] Number of Ways to Paint N × 3 Grid
 */

// @lc code=start
class Solution {
    public int numOfWays(int n) {
        long two = 6, three = 6;
        while (n > 1) {
            long newTwo = 3 * two + 2 * three, newThree = 2 * two + 2 * three;
            two = newTwo % 1000000007;
            three = newThree % 1000000007;
            --n;
        }
        return (int)((two + three) % 1000000007);
    }
}
// @lc code=end

