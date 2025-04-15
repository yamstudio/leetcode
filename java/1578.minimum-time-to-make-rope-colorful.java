/*
 * @lc app=leetcode id=1578 lang=java
 *
 * [1578] Minimum Time to Make Rope Colorful
 */

// @lc code=start
class Solution {
    public int minCost(String colors, int[] neededTime) {
        int n = neededTime.length, sum = 0, max = 0, ret = 0;
        char color = '-';
        for (int i = 0; i < n; ++i) {
            char c = colors.charAt(i);
            int t = neededTime[i];
            if (c == color) {
                sum += t;
                max = Math.max(max, t);
                continue;
            }
            color = c;
            ret += sum - max;
            sum = t;
            max = t;
        }
        return ret + sum - max;
    }
}
// @lc code=end

