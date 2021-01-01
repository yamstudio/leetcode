/*
 * @lc app=leetcode id=1654 lang=csharp
 *
 * [1654] Minimum Jumps to Reach Home
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static int MinimumJumps(HashSet<int> forbidden, int a, int b, int x, int lim, int curr, bool forward, HashSet<int> seen, IDictionary<(int Index, bool Forward), int> memo) {
        if (curr == x) {
            return 0;
        }
        var key = (Index: curr, Forward: forward);
        if (memo.TryGetValue(key, out var ret)) {
            return ret;
        }
        ret = int.MaxValue;
        int f = curr + a, k = curr - b;
        seen.Add(curr);
        if (f <= lim && !forbidden.Contains(f) && !seen.Contains(f)) {
            int fr = MinimumJumps(forbidden, a, b, x, lim, f, true, seen, memo);
            if (fr < int.MaxValue) {
                ret = 1 + fr;
            }
        }
        if (forward && k > 0 && !forbidden.Contains(k) && !seen.Contains(k)) {
            int kr = MinimumJumps(forbidden, a, b, x, lim, k, false, seen, memo);
            if (kr < int.MaxValue) {
                ret = Math.Min(1 + kr, ret);
            }
        }
        seen.Remove(curr);
        return memo[key] = ret;
    }

    public int MinimumJumps(int[] forbidden, int a, int b, int x) {
        int ret = MinimumJumps(new HashSet<int>(forbidden), a, b, x, forbidden.Append(x).Max() + a * 2 + b * 2, 0, true, new HashSet<int>(), new Dictionary<(int Index, bool Forward), int>());
        return ret == int.MaxValue ? -1 : ret;
    }
}
// @lc code=end

