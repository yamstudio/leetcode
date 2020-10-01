/*
 * @lc app=leetcode id=1284 lang=csharp
 *
 * [1284] Minimum Number of Flips to Convert Binary Matrix to Zero Matrix
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static void Flip(int m, int n, int i, int j, ref int curr) {
        if (i < 0 || i >= m || j < 0 || j >= n) {
            return;
        }
        curr ^= (1 << (i * n + j));
    }

    public int MinFlips(int[][] mat) {
        int m = mat.Length, n = mat[0].Length, start = 0, steps = 0;
        var visited = new HashSet<int>();
        var queue = new Queue<int>();
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                start |= (mat[i][j] << (i * n + j));
            }
        }
        visited.Add(start);
        queue.Enqueue(start);
        while (queue.Count > 0) {
            for (int k = queue.Count; k > 0; --k) {
                int curr = queue.Dequeue();
                if (curr == 0) {
                    return steps;
                }
                for (int i = 0; i < m; ++i) {
                    for (int j = 0; j < n; ++j) {
                        int next = curr;
                        Flip(m, n, i, j, ref next);
                        Flip(m, n, i - 1, j, ref next);
                        Flip(m, n, i + 1, j, ref next);
                        Flip(m, n, i, j - 1, ref next);
                        Flip(m, n, i, j + 1, ref next);
                        if (visited.Add(next)) {
                            queue.Enqueue(next);
                        }
                    }
                }
            }
            ++steps;
        }
        return -1;
    }
}
// @lc code=end

