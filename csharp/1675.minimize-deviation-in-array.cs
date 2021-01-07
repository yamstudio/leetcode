/*
 * @lc app=leetcode id=1675 lang=csharp
 *
 * [1675] Minimize Deviation in Array
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int MinimumDeviation(int[] nums) {
        var sorted = new SortedSet<int>();
        int ret = int.MaxValue;
        foreach (var num in nums) {
            if (num % 2 == 1) {
                sorted.Add(num * 2);
            } else {
                sorted.Add(num);
            }
        }
        ret = sorted.Max - sorted.Min;
        while (true) {
            int max = sorted.Max;
            ret = Math.Min(ret, sorted.Max - sorted.Min);
            if (max % 2 == 1) {
                break;
            }
            sorted.Remove(max);
            sorted.Add(max / 2);
        }
        return ret;
    }
}
// @lc code=end

