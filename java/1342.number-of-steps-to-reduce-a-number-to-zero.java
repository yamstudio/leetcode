/*
 * @lc app=leetcode id=1342 lang=java
 *
 * [1342] Number of Steps to Reduce a Number to Zero
 */

// @lc code=start
class Solution {
    public int numberOfSteps(int num) {
        if (num == 0) {
            return 0;
        }
        if (num % 2 == 0) {
            return 1 + numberOfSteps(num / 2);
        }
        return 1 + numberOfSteps(num - 1);
    }
}
// @lc code=end

