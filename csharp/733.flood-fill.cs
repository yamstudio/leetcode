/*
 * @lc app=leetcode id=733 lang=csharp
 *
 * [733] Flood Fill
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    
    private static IEnumerable<(int r, int c)> GetNeighbors(int r, int c) {
        yield return (r: r - 1, c: c);
        yield return (r: r + 1, c: c);
        yield return (r: r, c: c - 1);
        yield return (r: r, c: c + 1);
    }
    
    public int[][] FloodFill(int[][] image, int sr, int sc, int newColor) {
        int m = image.Length, n = image[0].Length, oldColor = image[sr][sc];
        if (oldColor == newColor) {
            return image;
        }
        Queue<(int r, int c)> queue = new Queue<(int r, int c)>();
        image[sr][sc] = newColor;
        queue.Enqueue((r: sr, c: sc));
        while (queue.Count > 0) {
            var loc = queue.Dequeue();
            foreach (var nb in GetNeighbors(loc.r, loc.c).Where(nb => nb.r >= 0 && nb.r < m && nb.c >= 0 && nb.c < n && oldColor == image[nb.r][nb.c])) {
                image[nb.r][nb.c] = newColor;
                queue.Enqueue(nb);
            }
        }
        return image;
    }
}
// @lc code=end

