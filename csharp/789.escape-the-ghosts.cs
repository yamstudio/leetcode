/*
 * @lc app=leetcode id=789 lang=csharp
 *
 * [789] Escape The Ghosts
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    public bool EscapeGhosts(int[][] ghosts, int[] target) {
        int dist = Math.Abs(target[0]) + Math.Abs(target[1]);
        return ghosts
            .Select(ghost => Math.Abs(target[0] - ghost[0]) + Math.Abs(target[1] - ghost[1]))
            .All(d => d > dist);
    }
}
// @lc code=end

