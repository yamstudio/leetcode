/*
 * @lc app=leetcode id=1326 lang=csharp
 *
 * [1326] Minimum Number of Taps to Open to Water a Garden
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    public int MinTaps(int n, int[] ranges) {
        int ret = 0, pr = int.MinValue, r = 0;
        foreach (var curr in ranges
            .Select((int range, int index) => (Left: index - range, Right: index + range))
            .Where(t => t.Left != t.Right)
            .OrderBy(t => t.Left)) {
            if (curr.Left > r) {
                return -1;
            }
            if (curr.Left > pr) {
                pr = r;
                ++ret;
                if (curr.Right >= n) {
                    return ret;
                }
            }
            r = Math.Max(r, curr.Right);
            if (r >= n) {
                return ret;
            }
        }
        return -1;
    }
}
// @lc code=end

