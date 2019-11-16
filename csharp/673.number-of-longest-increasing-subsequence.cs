/*
 * @lc app=leetcode id=673 lang=csharp
 *
 * [673] Number of Longest Increasing Subsequence
 */

// @lc code=start
public class Solution {
    public int FindNumberOfLIS(int[] nums) {
        int n = nums.Length, ret = 0, m = 0;
        int[] count = new int[n], len = new int[n];
        for (int i = 0; i < n; ++i) {
            count[i] = 1;
            len[i] = 1;
            int val = nums[i];
            for (int j = 0; j < i; ++j) {
                if (val > nums[j]) {
                    if (len[i] == len[j] + 1) {
                        count[i] += count[j];
                    } else if (len[i] < len[j] + 1) {
                        len[i] = len[j] + 1;
                        count[i] = count[j];
                    }
                }
            }
            if (len[i] == m) {
                ret += count[i];
            } else if (len[i] > m) {
                m = len[i];
                ret = count[i];
            }
        }
        return ret;
    }
}
// @lc code=end

