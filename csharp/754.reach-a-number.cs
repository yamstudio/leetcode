/*
 * @lc app=leetcode id=754 lang=csharp
 *
 * [754] Reach a Number
 */

// @lc code=start
public class Solution {
    public int ReachNumber(int target) {
        int ret = 0, sum = 0;
        target = Math.Abs(target);
        while (sum < target || (sum - target) % 2 != 0) {
            sum += ++ret;
        }
        return ret;
    }
}
// @lc code=end

