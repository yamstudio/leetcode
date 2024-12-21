/*
 * @lc app=leetcode id=1051 lang=java
 *
 * [1051] Height Checker
 */

// @lc code=start
class Solution {
    public int heightChecker(int[] heights) {
        int[] count = new int[101];
        for (int h : heights) {
            ++count[h];
        }
        int ret = 0, curr = 0;
        for (int h : heights) {
            while (count[curr] == 0) {
                ++curr;
            }
            if (curr != h) {
                ++ret;
            }
            --count[curr];
        }
        return ret;
    }
}
// @lc code=end

