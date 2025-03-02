/*
 * @lc app=leetcode id=1402 lang=java
 *
 * [1402] Reducing Dishes
 */

import java.util.Arrays;

// @lc code=start

class Solution {
    public int maxSatisfaction(int[] satisfaction) {
        int n = satisfaction.length, acc = 0, ret = 0;
        Arrays.sort(satisfaction);
        for (int i = n - 1; i >= 0 && acc >= -satisfaction[i]; --i) {
            acc += satisfaction[i];
            ret += acc;
        }
        return ret;
    }
}
// @lc code=end

