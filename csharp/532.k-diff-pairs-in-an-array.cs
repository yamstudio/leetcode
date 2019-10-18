/*
 * @lc app=leetcode id=532 lang=csharp
 *
 * [532] K-diff Pairs in an Array
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int FindPairs(int[] nums, int k) {
        if (k < 0) {
            return 0;
        }
        IDictionary<int, int> count = new Dictionary<int, int>();
        int ret = 0;
        foreach (int num in nums) {
            int val = 0;
            count.TryGetValue(num, out val);
            count[num] = val + 1;
        }
        if (k == 0) {
            foreach (int curr in count.Values) {
                if (curr > 1) {
                    ++ret;
                }
            }
        } else {
            foreach (int num in count.Keys) {
                if (count.ContainsKey(num + k)) {
                    ++ret;
                }
            }
        }
        return ret;
    }
}
// @lc code=end

