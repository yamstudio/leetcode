/*
 * @lc app=leetcode id=1267 lang=csharp
 *
 * [1267] Count Servers that Communicate
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int CountServers(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        var set = new HashSet<(int R, int C)>();
        for (int i = 0; i < m; ++i) {
            bool flag = false;
            int pr = -1, pc = -1;
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 0) {
                    continue;
                }
                var curr = (R: i, C: j);
                if (flag) {
                    set.Add(curr);
                    continue;
                }
                if (pr < 0) {
                    pr = i;
                    pc = j;
                } else {
                    flag = true;
                    set.Add(curr);
                    set.Add((R: pr, C: pc));
                }
            }
        }
        for (int j = 0; j < n; ++j) {
            bool flag = false;
            int pr = -1, pc = -1;
            for (int i = 0; i < m; ++i) {
                if (grid[i][j] == 0) {
                    continue;
                }
                var curr = (R: i, C: j);
                if (flag) {
                    set.Add(curr);
                    continue;
                }
                if (pr < 0) {
                    pr = i;
                    pc = j;
                } else {
                    flag = true;
                    set.Add(curr);
                    set.Add((R: pr, C: pc));
                }
            }
        }
        return set.Count;
    }
}
// @lc code=end

