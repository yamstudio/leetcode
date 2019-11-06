/*
 * @lc app=leetcode id=632 lang=csharp
 *
 * [632] Smallest Range Covering Elements from K Lists
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int[] SmallestRange(IList<IList<int>> nums) {
        int n = nums.Count, covered = 0, start = 0, len = int.MaxValue;
        int[] map = new int[n], ret = new int[2];
        var sorted = nums.SelectMany((list, i) => list.Select(x => (x, i))).OrderBy(pair => pair.x).ToArray();
        int total = sorted.Length;
        for (int end = 0; end < total; ++end) {
            var curr = sorted[end];
            if (map[curr.i]++ == 0) {
                ++covered;
            }
            while (covered == n && start <= end) {
                int l = sorted[start].x, r = sorted[end].x;
                if (len > r - l) {
                    ret[0] = l;
                    ret[1] = r;
                    len = r - l;
                }
                if (--map[sorted[start].i] == 0) {
                    --covered;
                }
                ++start;
            }
        }
        return ret;
    }
}
// @lc code=end

