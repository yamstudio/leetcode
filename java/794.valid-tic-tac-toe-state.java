/*
 * @lc app=leetcode id=794 lang=java
 *
 * [794] Valid Tic-Tac-Toe State
 */

// @lc code=start
class Solution {

    private static int[][][] combs = new int[][][] {
        new int[][] {
            new int[] { 0, 0 }, new int[] { 0, 1 }, new int[] { 0, 2 }
        },
        new int[][] {
            new int[] { 1, 0 }, new int[] { 1, 1 }, new int[] { 1, 2 }
        },
        new int[][] {
            new int[] { 2, 0 }, new int[] { 2, 1 }, new int[] { 2, 2 }
        },
        new int[][] {
            new int[] { 0, 0 }, new int[] { 1, 0 }, new int[] { 2, 0 }
        },
        new int[][] {
            new int[] { 0, 1 }, new int[] { 1, 1 }, new int[] { 2, 1 }
        },
        new int[][] {
            new int[] { 0, 2 }, new int[] { 1, 2 }, new int[] { 2, 2 }
        },
        new int[][] {
            new int[] { 0, 0 }, new int[] { 1, 1 }, new int[] { 2, 2 }
        },
        new int[][] {
            new int[] { 0, 2 }, new int[] { 1, 1 }, new int[] { 2, 0 }
        }
    };

    private static boolean isWin(String[] board, char c) {
        return Arrays.stream(combs).anyMatch(comb -> Arrays.stream(comb).allMatch(p -> board[p[0]].charAt(p[1]) == c));
    }

    public boolean validTicTacToe(String[] board) {
        int x = 0, o = 0;
        for (int i = 0; i < 3; ++i) {
            for (int j = 0; j < 3; ++j) {
                if (board[i].charAt(j) == 'X') {
                    ++x;
                } else if (board[i].charAt(j) == 'O') {
                    ++o;
                }
            }
        }
        return x == o && !isWin(board, 'X') || x == o + 1 && !isWin(board, 'O');
    }
}
// @lc code=end

