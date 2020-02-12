/*
 * @lc app=leetcode id=840 lang=csharp
 *
 * [840] Magic Squares In Grid
 */

using System.Linq;

// @lc code=start
public class Solution {

    private static bool IsMagic(int[][] grid, int x, int y) {
        int a = grid[x][y], b = grid[x][y + 1], c = grid[x][y + 2], d = grid[x + 1][y], e = grid[x + 1][y + 1], f = grid[x + 1][y + 2], g = grid[x + 2][y], h = grid[x + 2][y + 1], i = grid[x + 2][y + 2];
        return e == 5 &&
            (new int[] { a, b, c, d, e, f, g, h, i }).Distinct().Where(v => v >= 0 && v <= 9).Count() == 9 && 
            15 == a + b + c &&
            15 == d + e + f &&
            15 == g + h + i &&
            15 == a + d + g &&
            15 == b + e + h &&
            15 == c + f + i &&
            15 == a + e + i &&
            15 == c + e + g;
    }

    public int NumMagicSquaresInside(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        if (m < 3 || n < 3) {
            return 0;
        }
        return Enumerable
            .Range(0, m - 2)
            .Select(x => Enumerable
                .Range(0, n - 2)
                .Where(y => IsMagic(grid, x, y))
                .Count())
            .Sum();
    }
}
// @lc code=end

