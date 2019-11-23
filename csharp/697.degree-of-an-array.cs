/*
 * @lc app=leetcode id=697 lang=csharp
 *
 * [697] Degree of an Array
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int FindShortestSubArray(int[] nums) {
        IDictionary<int, int[]> map = new Dictionary<int, int[]>();
        int n = nums.Length, max = 0;
        for (int i = 0; i < n; ++i) {
            int num = nums[i];
            int[] val;
            if (!map.TryGetValue(num, out val)) {
                val = new int[] { 1, i, i, };
                map[num] = val;
            } else {
                val[0]++;
                val[2] = i;
            }
            max = Math.Max(val[0], max);
        }
        int ret = int.MaxValue;
        foreach (int[] val in map.Values) {
            if (val[0] < max) {
                continue;
            }
            ret = Math.Min(ret, val[2] - val[1] + 1);
        }
        return ret;
    }
}
// @lc code=end

