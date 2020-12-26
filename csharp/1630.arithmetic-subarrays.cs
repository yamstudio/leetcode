/*
 * @lc app=leetcode id=1630 lang=csharp
 *
 * [1630] Arithmetic Subarrays
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public IList<bool> CheckArithmeticSubarrays(int[] nums, int[] l, int[] r) {
        int n = l.Length;
        var ret = new List<bool>(n);
        for (int i = 0; i < n; ++i) {
            int li = l[i], ri = r[i], max = int.MinValue, min = int.MaxValue;
            for (int j = li; j <= ri; ++j) {
                max = Math.Max(max, nums[j]);
                min = Math.Min(min, nums[j]);
            }
            if (max == min) {
                ret.Add(true);
                continue;
            }
            if ((max - min) % (ri - li) != 0) {
                ret.Add(false);
                continue;
            }
            int g = (max - min) / (ri - li);
            bool[] seen = new bool[ri - li + 1];
            bool flag = true;
            for (int j = li; j <= ri; ++j) {
                if ((nums[j] - min) % g != 0 || seen[(nums[j] - min) / g]) {
                    flag = false;
                    break;
                }
                seen[(nums[j] - min) / g] = true;
            }
            ret.Add(flag);
        }
        return ret;
    }
}
// @lc code=end

