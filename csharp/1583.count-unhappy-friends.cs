/*
 * @lc app=leetcode id=1583 lang=csharp
 *
 * [1583] Count Unhappy Friends
 */

// @lc code=start
public class Solution {
    public int UnhappyFriends(int n, int[][] preferences, int[][] pairs) {
        int[] map = new int[n];
        int[,] pmap = new int[n, n];
        int ret = 0;
        foreach (var pair in pairs) {
            map[pair[0]] = pair[1];
            map[pair[1]] = pair[0];
        }
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n - 1; ++j) {
                pmap[i, preferences[i][j]] = j;
            }
        }
        for (int i = 0; i < n; ++i) {
            int p = map[i];
            for (int j = 0; j < n; ++j) {
                if (j == i || j == p) {
                    continue;
                }
                int jp = map[j];
                if (pmap[i, j] < pmap[i, p] && pmap[j, i] < pmap[j, jp]) {
                    ++ret;
                    break;
                }
            }
        }
        return ret;
    }
}
// @lc code=end

