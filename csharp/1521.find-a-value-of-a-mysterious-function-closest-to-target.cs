/*
 * @lc app=leetcode id=1521 lang=csharp
 *
 * [1521] Find a Value of a Mysterious Function Closest to Target
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int ClosestToTarget(int[] arr, int target) {
        int ret = int.MaxValue;
        var all = new HashSet<int>();
        foreach (int x in arr) {
            var next = new HashSet<int>() { x };
            ret = Math.Min(ret, Math.Abs(x - target));
            foreach (int y in all) {
                ret = Math.Min(ret, Math.Abs((x & y) - target));
                next.Add(x & y);
            }
            all = next;
        }
        return ret;
    }
}
// @lc code=end

