/*
 * @lc app=leetcode id=1033 lang=csharp
 *
 * [1033] Moving Stones Until Consecutive
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int[] NumMovesStones(int a, int b, int c) {
        var sorted = (new int[] { a, b, c }).OrderBy(x => x).ToArray();
        int l = sorted[0], m = sorted[1], r = sorted[2];
        if (r == l + 2) {
            return new int[] { 0, 0 };
        }
        return new int[] {
            m <= l + 2 || m >= r - 2 ? 1 : 2,
            r - l - 2
        };
    }
}
// @lc code=end

