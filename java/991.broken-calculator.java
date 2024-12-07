/*
 * @lc app=leetcode id=991 lang=java
 *
 * [991] Broken Calculator
 */

// @lc code=start
class Solution {
    public int brokenCalc(int startValue, int target) {
        if (startValue >= target) {
            return startValue - target;
        }
        return 1 + brokenCalc(startValue, target % 2 == 0 ? target / 2 : (target + 1));
    }
}
// @lc code=end

