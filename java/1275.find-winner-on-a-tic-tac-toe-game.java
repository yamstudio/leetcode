/*
 * @lc app=leetcode id=1275 lang=java
 *
 * [1275] Find Winner on a Tic Tac Toe Game
 */

// @lc code=start
class Solution {

    private static final int[] WINS = new int[] {
        0b111,
        0b111000,
        0b111000000,
        0b100100100,
        0b10010010,
        0b1001001,
        0b100010001,
        0b1010100
    };

    public String tictactoe(int[][] moves) {
        int[] state = new int[] { 0, 0 };
        int i = 0;
        for (int[] move : moves) {
            state[i] |= 1 << (move[0] * 3 + move[1]);
            i = 1 - i;
        }
        for (int win : WINS) {
            if ((win & state[0]) == win) {
                return "A";
            }
            if ((win & state[1]) == win) {
                return "B";
            }
        }
        return moves.length == 9 ? "Draw" : "Pending";
    }
}
// @lc code=end

