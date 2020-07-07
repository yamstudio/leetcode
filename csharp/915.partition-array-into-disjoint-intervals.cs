/*
 * @lc app=leetcode id=915 lang=csharp
 *
 * [915] Partition Array into Disjoint Intervals
 */

using System;

// @lc code=start
public class Solution {
    public int PartitionDisjoint(int[] A) {
        int p = 0, pre = A[0], curr = pre, n = A.Length;
        for (int i = 0; i < n; ++i) {
            int v = A[i];
            curr = Math.Max(v, curr);
            if (v < pre) {
                pre = curr;
                p = i;
            }
        }
        return p + 1;
    }
}
// @lc code=end

