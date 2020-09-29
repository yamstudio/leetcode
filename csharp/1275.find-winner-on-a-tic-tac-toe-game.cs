/*
 * @lc app=leetcode id=1275 lang=csharp
 *
 * [1275] Find Winner on a Tic Tac Toe Game
 */

// @lc code=start
public class Solution {

    private static bool HasBit(int b, int r, int c) {
        return ((b & (1 << (3 * (r % 3) + (c % 3)))) != 0);
    }

    public string Tictactoe(int[][] moves) {
        int b = 0, n = moves.Length, r = moves[n - 1][0], c = moves[n - 1][1];
        for (int i = n - 3; i >= 0; i -= 2) {
            b |= (1 << (3 * moves[i][0] + moves[i][1]));
        }
        if (HasBit(b, r + 1, c) && HasBit(b, r + 2, c)) {
            return n % 2 == 1 ? "A" : "B";
        }
        if (HasBit(b, r, c + 1) && HasBit(b, r, c + 2)) {
            return n % 2 == 1 ? "A" : "B";
        }
        if (r == c && HasBit(b, r + 1, c + 1) && HasBit(b, r + 2, c + 2)) {
            return n % 2 == 1 ? "A" : "B";
        }
        if (r == 2 - c && HasBit(b, r + 2, c + 1) && HasBit(b, r + 1, c + 2)) {
            return n % 2 == 1 ? "A" : "B";
        }
        return n == 9 ? "Draw" : "Pending";
    }
}
// @lc code=end

