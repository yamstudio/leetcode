/*
 * @lc app=leetcode id=1301 lang=csharp
 *
 * [1301] Number of Paths with Max Score
 */

// @lc code=start
public class Solution {

    private static (int R, int C)[] Dirs = new (int R, int C)[] {
        (R: 1, C: 0),
        (R: 0, C: 1),
        (R: 1, C: 1)
    };

    public int[] PathsWithMaxScore(IList<string> board) {
        int n = board.Count;
        int[,,] dp = new int[n + 1, n + 1, 2];
        dp[n - 1, n - 1, 1] = 1;
        for (int i = n - 1; i >= 0; --i) {
            for (int j = n - 1; j >= 0; --j) {
                if (board[i][j] == 'S' || board[i][j] == 'X') {
                    continue;
                }
                foreach (var dir in Dirs) {
                    int ni = i + dir.R, nj = j + dir.C;
                    if (dp[i, j, 0] < dp[ni, nj, 0]) {
                        dp[i, j, 0] = dp[ni, nj, 0];
                        dp[i, j, 1] = dp[ni, nj, 1];
                    } else if (dp[i, j, 0] == dp[ni, nj, 0]) {
                        dp[i, j, 1] = (dp[i, j, 1] + dp[ni, nj, 1]) % 1000000007;
                    }
                }
                if (i != 0 || j != 0) {
                    dp[i, j, 0] += (int)board[i][j] - (int)'0';
                }

            }
        }
        if (dp[0, 0, 1] == 0) {
            return new int[] { 0, 0 };
        }
        return new int[] { dp[0, 0, 0], dp[0, 0, 1] };
    }
}
// @lc code=end

