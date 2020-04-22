/*
 * @lc app=leetcode id=888 lang=csharp
 *
 * [888] Fair Candy Swap
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int[] FairCandySwap(int[] A, int[] B) {
        var sa = new HashSet<int>();
        var sb = new HashSet<int>();
        int diff = 0;
        foreach (var a in A) {
            diff += a;
            sa.Add(a);
        }
        foreach (var b in B) {
            diff -= b;
            sb.Add(b);
        }
        diff /= 2;
        foreach (var a in sa) {
            if (sb.Contains(a - diff)) {
                return new int[] { a, a - diff };
            }
        }
        return new int[0];
    }
}
// @lc code=end

