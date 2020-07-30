/*
 * @lc app=leetcode id=976 lang=csharp
 *
 * [976] Largest Perimeter Triangle
 */

using System;

// @lc code=start
public class Solution {
    public int LargestPerimeter(int[] A) {
        Array.Sort(A);
        for (int i = A.Length - 1; i > 1; --i) {
            int l = A[i], m = A[i - 1], s = A[i - 2];
            if (m + s > l) {
                return l + s + m;
            }
        }
        return 0;
    }
}
// @lc code=end

