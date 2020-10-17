/*
 * @lc app=leetcode id=1342 lang=csharp
 *
 * [1342] Number of Steps to Reduce a Number to Zero
 */

// @lc code=start
public class Solution {
    public int NumberOfSteps (int num) {
        if (num == 0) {
            return 0;
        }
        int ret = -1;
        while (num != 0) {
            if ((num & 1) == 1) {
                ret += 2;
            } else {
                ret += 1;
            }
            num >>= 1;
        }
        return ret;
    }
}
// @lc code=end

