/*
 * @lc app=leetcode id=1791 lang=java
 *
 * [1791] Find Center of Star Graph
 */

// @lc code=start
class Solution {
    public int findCenter(int[][] edges) {
        int a = edges[0][0], b = edges[0][1], c = edges[1][0], d = edges[1][1];
        if (a == c || a == d) {
            return a;
        }
        return b;
    }
}
// @lc code=end

