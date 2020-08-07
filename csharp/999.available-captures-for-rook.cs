/*
 * @lc app=leetcode id=999 lang=csharp
 *
 * [999] Available Captures for Rook
 */

// @lc code=start
public class Solution {

    private static (int R, int C)[] Dirs = new (int R, int C)[] {
        (R: -1, C: 0),
        (R: 1, C: 0),
        (R: 0, C: -1),
        (R: 0, C: 1)
    };

    public int NumRookCaptures(char[][] board) {
        for (int i = 0; i < 8; ++i) {
            for (int j = 0; j < 8; ++j) {
                if (board[i][j] != 'R') {
                    continue;
                }
                int ret = 0;
                foreach (var dir in Dirs) {
                    for (int ni = i, nj = j; ni >= 0 && ni < 8 && nj >= 0 && nj < 8; ni += dir.R, nj += dir.C) {
                        int v = board[ni][nj];
                        if (v == 'B') {
                            break;
                        }
                        if (v == 'p') {
                            ++ret;
                            break;
                        }
                    }
                }
                return ret;
            }
        }
        return -1;
    }
}
// @lc code=end

