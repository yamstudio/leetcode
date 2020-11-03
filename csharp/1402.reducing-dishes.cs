/*
 * @lc app=leetcode id=1402 lang=csharp
 *
 * [1402] Reducing Dishes
 */

using System;

// @lc code=start
public class Solution {
    public int MaxSatisfaction(int[] satisfaction) {
        int n = satisfaction.Length, ret = 0, acc = 0;
        Array.Sort(satisfaction);
        for (int i = n - 1; i >= 0 && acc >= -satisfaction[i]; --i) {
            acc += satisfaction[i];
            ret += acc;
        }
        return ret;
    }
}
// @lc code=end

