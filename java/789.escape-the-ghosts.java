/*
 * @lc app=leetcode id=789 lang=java
 *
 * [789] Escape The Ghosts
 */

// @lc code=start
class Solution {
    public boolean escapeGhosts(int[][] ghosts, int[] target) {
        int d = Math.abs(target[0]) + Math.abs(target[1]);
        return Arrays.stream(ghosts).allMatch(g -> Math.abs(target[0] - g[0]) + Math.abs(target[1] - g[1]) > d);
    }
}
// @lc code=end

