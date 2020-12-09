/*
 * @lc app=leetcode id=1546 lang=csharp
 *
 * [1546] Maximum Number of Non-Overlapping Subarrays With Sum Equals Target
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int MaxNonOverlapping(int[] nums, int target) {
        var map = new Dictionary<int, int>();
        int ret = 0, acc = 0;
        map[0] = 0;
        foreach (int x in nums) {
            acc += x;
            if (map.TryGetValue(acc - target, out int p)) {
                ret = Math.Max(ret, p + 1);
            }
            map[acc] = ret;
        }
        return ret;
    }
}
// @lc code=end

