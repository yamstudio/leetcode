/*
 * @lc app=leetcode id=907 lang=csharp
 *
 * [907] Sum of Subarray Minimums
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int SumSubarrayMins(int[] A) {
        int ret = 0, n = A.Length;
        int[] left = new int[n], right = new int[n];
        Stack<(int Index, int Value)> ls = new Stack<(int Index, int Value)>(), rs = new Stack<(int Index, int Value)>();
        for (int i = 0; i < n; ++i) {
            int val = A[i];
            while (ls.Count > 0 && ls.Peek().Value > val) {
                ls.Pop();
            }
            while (rs.Count > 0 && rs.Peek().Value > val) {
                var pop = rs.Pop();
                right[pop.Index] = i - pop.Index;
            }
            left[i] = ls.Count == 0 ? (i + 1) : (i - ls.Peek().Index);
            right[i] = n - i;
            var push = (Index: i, Value: val);
            ls.Push(push);
            rs.Push(push);
        }
        for (int i = 0; i < n; ++i) {
            ret = (ret + A[i] * left[i] * right[i]) % 1000000007;
        }
        return ret;
    }
}
// @lc code=end

