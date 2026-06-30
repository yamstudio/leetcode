/*
 * @lc app=leetcode id=1780 lang=java
 *
 * [1780] Check if Number is a Sum of Powers of Three
 */

// @lc code=start
class Solution {
    public boolean checkPowersOfThree(int n) {
        return checkPowersOfThree(n, 1);
    }

    
    private static boolean checkPowersOfThree(int n, int b) {
        if (n == 0) {
            return true;
        }
        for (int t = b; t <= n; t *= 3) {
            if (checkPowersOfThree(n - t, t * 3)) {
                return true;
            }
        } 
        return false;
    }
}
// @lc code=end

