/*
 * @lc app=leetcode id=554 lang=csharp
 *
 * [554] Brick Wall
 */

using System.Linq;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int LeastBricks(IList<IList<int>> wall) {
        IDictionary<int, int> map = new Dictionary<int, int>();
        int max = 0;
        foreach (var row in wall) {
            int curr = 0;
            foreach (var brick in row.SkipLast(1)) {
                curr += brick;
                int count = 0;
                map.TryGetValue(curr, out count);
                ++count;
                max = Math.Max(max, count);
                map[curr] = count;
            }
        }
        return wall.Count - max;
    }
}
// @lc code=end

