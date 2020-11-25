/*
 * @lc app=leetcode id=1487 lang=csharp
 *
 * [1487] Making File Names Unique
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public string[] GetFolderNames(string[] names) {
        int n = names.Length;
        var ret = new string[n];
        var map = new Dictionary<string, int>();
        for (int i = 0; i < n; ++i) {
            string name = names[i];
            if (!map.TryGetValue(name, out var c)) {
                ret[i] = name;
                map[name] = 0;
                continue;
            }
            string newName;
            do {
                newName = $"{name}({++c})";
            } while (map.ContainsKey(newName));
            map[name] = c;
            map[newName] = 0;
            ret[i] = newName;
        }
        return ret;
    }
}
// @lc code=end

