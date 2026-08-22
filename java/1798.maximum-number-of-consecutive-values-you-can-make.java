/*
 * @lc app=leetcode id=1798 lang=java
 *
 * [1798] Maximum Number of Consecutive Values You Can Make
 */

import java.util.Arrays;

// @lc code=start

class Solution {
    public int getMaximumConsecutive(int[] coins) {
        int ret = 1;
        Arrays.sort(coins);
        for (int c : coins) {
            if (c > ret) {
                break;
            }
            ret += c;
        }
        return ret;
    }
}
// @lc code=end

