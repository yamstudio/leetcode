/*
 * @lc app=leetcode id=525 lang=csharp
 *
 * [525] Contiguous Array
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int FindMaxLength(int[] nums) {
        int ret = 0, n = nums.Length, curr = 0;
        IDictionary<int, int> map = new Dictionary<int, int>();
        map.Add(0, -1);
        for (int i = 0; i < n; ++i) {
            curr += nums[i] == 0 ? 1 : -1;
            int j;
            if (map.TryGetValue(curr, out j)) {
                ret = Math.Max(ret, i - j);
            } else {
                map[curr] = i;
            }
        }
        return ret;
    }
}
// @lc code=end

