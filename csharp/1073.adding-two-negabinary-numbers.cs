/*
 * @lc app=leetcode id=1073 lang=csharp
 *
 * [1073] Adding Two Negabinary Numbers
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int[] AddNegabinary(int[] arr1, int[] arr2) {
        int l1 = arr1.Length, l2 = arr2.Length, carry = 0;
        var ret = new List<int>();
        for (int i = 1; carry != 0 || i <= l1 || i <= l2; ++i) {
            if (i <= l1) {
                carry += arr1[l1 - i];
            }
            if (i <= l2) {
                carry += arr2[l2 - i];
            }
            ret.Add(carry & 1);
            carry = -(carry >> 1);
        }
        while (ret.Count > 1 && ret[ret.Count - 1] == 0) {
            ret.RemoveAt(ret.Count - 1);
        }
        ret.Reverse();
        return ret.ToArray();
    }
}
// @lc code=end

