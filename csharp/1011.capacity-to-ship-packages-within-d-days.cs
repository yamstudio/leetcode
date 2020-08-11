/*
 * @lc app=leetcode id=1011 lang=csharp
 *
 * [1011] Capacity To Ship Packages Within D Days
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int ShipWithinDays(int[] weights, int D) {
        int l = weights.Max(), r = weights.Sum();
        while (l < r) {
            int m = (l + r) / 2, count = 1, curr = 0;
            foreach (int w in weights) {
                if (w + curr > m) {
                    if (++count > D) {
                        break;
                    }
                    curr = w;
                } else {
                    curr += w;
                }
            }
            if (count <= D) {
                r = m;
            } else {
                l = m + 1;
            }
        }
        return l;
    }
}
// @lc code=end

