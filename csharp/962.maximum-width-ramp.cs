/*
 * @lc app=leetcode id=962 lang=csharp
 *
 * [962] Maximum Width Ramp
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int MaxWidthRamp(int[] A) {
        var stack = new Stack<(int Value, int Index)>();
        int ret = 0, n = A.Length;
        for (int i = 0; i < n; ++i) {
            int curr = A[i];
            if (!stack.TryPeek(out var tuple) || tuple.Value > curr) {
                stack.Push((Value: curr, Index: i));
            }
        }
        for (int i = n - 1; i > 0; --i) {
            int curr = A[i];
            while (stack.TryPeek(out var tuple) && tuple.Value <= curr) {
                ret = Math.Max(ret, i - stack.Pop().Index);
            }
        }
        return ret;
    }
}
// @lc code=end

