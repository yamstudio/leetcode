/*
 * @lc app=leetcode id=945 lang=csharp
 *
 * [945] Minimum Increment to Make Array Unique
 */

using System;

// @lc code=start
public class Solution {
    public int MinIncrementForUnique(int[] A) {
        int ret = 0, m = 0;
        Array.Sort(A);
        foreach (int num in A) {
            if (num >= m) {
                m = num + 1;
            } else {
                ret += m - num;
                ++m;
            }
        }
        return ret;
    }
}
// @lc code=end

