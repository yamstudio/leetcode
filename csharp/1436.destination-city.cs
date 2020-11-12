/*
 * @lc app=leetcode id=1436 lang=csharp
 *
 * [1436] Destination City
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public string DestCity(IList<IList<string>> paths) {
        var map = new Dictionary<string, string>();
        foreach (var path in paths) {
            map[path[0]] = path[1];
        }
        string curr = paths[0][0];
        while (map.TryGetValue(curr, out string next)) {
            curr = next;
        }
        return curr;
    }
}
// @lc code=end

