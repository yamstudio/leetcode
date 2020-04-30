/*
 * @lc app=leetcode id=908 lang=csharp
 *
 * [908] Smallest Range I
 */

using System;

// @lc code=start
public class Solution {
    public int SmallestRangeI(int[] A, int K) {
        int min = int.MaxValue, max = int.MinValue;
        foreach (var x in A) {
            if (x < min) {
                min = x;
            }
            if (x > max) {
                max = x;
            }
        }
        return Math.Max(0, max - min - 2 * K);
    }
}
// @lc code=end

