/*
 * @lc app=leetcode id=898 lang=csharp
 *
 * [898] Bitwise ORs of Subarrays
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int SubarrayBitwiseORs(int[] A) {
        var ret = new HashSet<int>(A);
        var prev = new HashSet<int>();
        foreach (var x in A) {
            var curr = new HashSet<int>() { x };
            foreach (var r in prev) {
                int val = x | r;
                curr.Add(val);
                ret.Add(val);
            }
            prev = curr;
        }
        return ret.Count;
    }
}
// @lc code=end

