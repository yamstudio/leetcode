/*
 * @lc app=leetcode id=1349 lang=java
 *
 * [1349] Maximum Students Taking Exam
 */

// @lc code=start
class Solution {
    public int maxStudents(char[][] seats) {
        int m = seats.length, n = seats[0].length, total = 1 << n;
        int[] prev = new int[total], curr = new int[total], count = new int[total];
        for (int state = 1; state < total; ++state) {
            count[state] = count[state >> 1] + (state & 1);
        }
        prev[0] = 1;
        for (int i = 0; i < m; ++i) {
            int row = 0;
            for (int j = 0; j < n; ++j) {
                row = (row << 1) | (seats[i][j] == '.' ? 1 : 0);
            }
            for (int state = 0; state < total; ++state) {
                curr[state] = 0;
                if ((row & state) != state) {
                    continue;
                }
                if ((state & (state >> 1)) != 0) {
                    continue;
                }
                for (int p = 0; p < total; ++p) {
                    if (prev[p] > 0 && (state & (p << 1)) == 0 && (state & (p >> 1)) == 0) {
                        curr[state] = Math.max(curr[state], count[state] + prev[p]);
                    }
                }
            }
            int[] tmp = curr;
            curr = prev;
            prev = tmp;
        }
        int ret = 0;
        for (int state = 0; state < total; ++state) {
            ret = Math.max(ret, prev[state]);
        }
        return ret - 1;
    }
}
// @lc code=end

