/*
 * @lc app=leetcode id=1583 lang=java
 *
 * [1583] Count Unhappy Friends
 */

// @lc code=start
class Solution {
    public int unhappyFriends(int n, int[][] preferences, int[][] pairs) {
        int ret = 0;
        int[] friends = new int[n];
        int[][] prefs = new int[n][n];
        for (int[] pair : pairs) {
            friends[pair[0]] = pair[1];
            friends[pair[1]] = pair[0];
        }
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n - 1; ++j) {
                prefs[i][preferences[i][j]] = j;
            }
        }
        for (int i = 0; i < n; ++i) {
            int f = friends[i];
            for (int j = 0; j < n; ++j) {
                if (i == j || f == j) {
                    continue;
                }
                if (prefs[i][j] < prefs[i][f] && prefs[j][i] < prefs[j][friends[j]]) {
                    ++ret;
                    break;
                }
            }
        }
        return ret;
    }
}
// @lc code=end

