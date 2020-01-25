/*
 * @lc app=leetcode id=781 lang=csharp
 *
 * [781] Rabbits in Forest
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int NumRabbits(int[] answers) {
        var map = new Dictionary<int, int>();
        foreach (var x in answers) {
            if (map.TryGetValue(x, out int count)) {
                map[x] = count + 1;
            } else {
                map[x] = 1;
            }
        }
        int ret = 0;
        foreach (var pair in map) {
            int k = pair.Key + 1, v = pair.Value;
            ret += k * ((v + k - 1) / k);
        }
        return ret;
    }
}
// @lc code=end

