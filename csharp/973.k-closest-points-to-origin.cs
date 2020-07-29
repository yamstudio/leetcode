/*
 * @lc app=leetcode id=973 lang=csharp
 *
 * [973] K Closest Points to Origin
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int[][] KClosest(int[][] points, int K) {
        return points
            .Select(point => (Point: point, Distance: point[0] * point[0] + point[1] * point[1]))
            .OrderBy(tuple => tuple.Distance)
            .Take(K)
            .Select(tuple => tuple.Point)
            .ToArray();
    }
}
// @lc code=end

