/*
 * @lc app=leetcode id=1007 lang=csharp
 *
 * [1007] Minimum Domino Rotations For Equal Row
 */

using System;

// @lc code=start
public class Solution {
    public int MinDominoRotations(int[] A, int[] B) {
        int ret = int.MaxValue, n = A.Length;
        for (int i = 1; i <= 6; ++i) {
            int ca = 0, cb = 0;
            bool flag = false;
            for (int j = 0; j < n; ++j) {
                int va = A[j], vb = B[j];
                if (va != i && vb != i) {
                    flag = true;
                    break;
                }
                if (va == i) {
                    if (vb == i) {
                        continue;
                    }
                    ++ca;
                } else if (vb == i) {
                    ++cb;
                }
            }
            if (!flag) {
                ret = Math.Min(ret, Math.Min(ca, cb));
            }
        }
        return ret == int.MaxValue ? -1 : ret;
    }
}
// @lc code=end

