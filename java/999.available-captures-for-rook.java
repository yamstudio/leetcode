/*
 * @lc app=leetcode id=999 lang=java
 *
 * [999] Available Captures for Rook
 */

// @lc code=start
class Solution {
    public int numRookCaptures(char[][] board) {
        int ret = 0, ri = -1, rj = -1;
        for (int i = 0; i < 8 && ri < 0; ++i) {
            for (int j = 0; j < 8 && rj < 0; ++j) {
                if (board[i][j] == 'R') {
                    ri = i;
                    rj = j;
                }
            }
        }
        for (int i = ri - 1; i >= 0; --i) {
            if (board[i][rj] == 'p') {
                ++ret;
                break;
            }
            if (board[i][rj] == 'B') {
                break;
            }
        }
        for (int i = ri + 1; i < 8; ++i) {
            if (board[i][rj] == 'p') {
                ++ret;
                break;
            }
            if (board[i][rj] == 'B') {
                break;
            }
        }
        for (int j = rj - 1; j >= 0; --j) {
            if (board[ri][j] == 'p') {
                ++ret;
                break;
            }
            if (board[ri][j] == 'B') {
                break;
            }
        }
        for (int j = rj + 1; j < 8; ++j) {
            if (board[ri][j] == 'p') {
                ++ret;
                break;
            }
            if (board[ri][j] == 'B') {
                break;
            }
        }
        return ret;
    }
}
// @lc code=end

