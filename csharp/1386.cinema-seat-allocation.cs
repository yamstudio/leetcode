/*
 * @lc app=leetcode id=1386 lang=csharp
 *
 * [1386] Cinema Seat Allocation
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int MaxNumberOfFamilies(int n, int[][] reservedSeats) {
        var taken = new Dictionary<int, int>();
        foreach (var t in reservedSeats) {
            if (!taken.TryGetValue(t[0], out var v)) {
                v = 0;
            }
            taken[t[0]] = v | (1 << t[1]);
        }
        int ret = 2 * (n - taken.Count);
        foreach (var p in taken) {
            int a = 0, t = p.Value;
            if ((t & 60) == 0) {
                ++a;
            }
            if ((t & 960) == 0) {
                ++a;
            }
            if (a == 0 && (t & 240) == 0) {
                ++a;
            }
            ret += a;
        }
        return ret;
    }
}
// @lc code=end

