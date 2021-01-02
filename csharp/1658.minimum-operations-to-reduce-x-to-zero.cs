/*
 * @lc app=leetcode id=1658 lang=csharp
 *
 * [1658] Minimum Operations to Reduce X to Zero
 */

using System;

// @lc code=start
public class Solution {
    public int MinOperations(int[] nums, int x) {
        int n = nums.Length, acc = 0, l, ret = int.MaxValue, r = n - 1;
        for (l = 0; l < n && acc < x; ++l) {
            acc += nums[l];
        }
        if (acc < x) {
            return -1;
        }
        --l;
        while (l >= 0) {
            if (acc == x) {
                ret = Math.Min(ret, n - r + l);
                acc -= nums[l--];
            } else if (acc > x) {
                acc -= nums[l--];
            } else {
                acc += nums[r--];
            }
        }
        while (acc < x) {
            acc += nums[r--];
        }
        if (acc == x) {
            ret = Math.Min(ret, n - 1 - r);
        }
        return ret == int.MaxValue ? -1 : ret;
    }
}
// @lc code=end

