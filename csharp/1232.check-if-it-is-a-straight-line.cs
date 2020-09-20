/*
 * @lc app=leetcode id=1232 lang=csharp
 *
 * [1232] Check If It Is a Straight Line
 */

using System.Linq;

// @lc code=start
public class Solution {
    public bool CheckStraightLine(int[][] coordinates) {
        var b = coordinates[0];
        var d = new int[] { b[0] - coordinates[1][0], b[1] - coordinates[1][1] };
        var others = coordinates.Skip(2);
        if (d[0] == 0) {
            return others.All(p => p[0] == b[0]);
        } else if (d[1] == 0) {
            return others.All(p => p[1] == b[1]);
        }
        return others.All(p => (p[0] - b[0]) * d[1] == (p[1] - b[1]) * d[0]);
    }
}
// @lc code=end

