/*
 * @lc app=leetcode id=997 lang=java
 *
 * [997] Find the Town Judge
 */

// @lc code=start
class Solution {
    public int findJudge(int n, int[][] trust) {
        int[] count = new int[n];
        for (var t : trust) {
            int l = t[0] - 1, r = t[1] - 1;
            count[l] = -1;
            if (count[r] != -1) {
                ++count[r];
            }
        }
        for (int i = 0; i < n; ++i) {
            if (count[i] == n - 1) {
                return i + 1;
            }
        }
        return -1;
    }
}
// @lc code=end

