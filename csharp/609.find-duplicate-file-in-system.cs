/*
 * @lc app=leetcode id=609 lang=csharp
 *
 * [609] Find Duplicate File in System
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public IList<IList<string>> FindDuplicate(string[] paths) {
        IDictionary<string, IList<string>> map = new Dictionary<string, IList<string>>();
        foreach (string path in paths) {
            var split = path.Split(' ');
            string dir = split[0];
            foreach (string file in split.Skip(1).DefaultIfEmpty()) {
                int m = file.IndexOf('(');
                string name = file.Substring(0, m);
                string content = file.Substring(m);
                if (!map.ContainsKey(content)) {
                    map[content] = new List<string>();
                }
                map[content].Add($"{dir}/{name}");
            }
        }
        return map.Values.Where(list => list.Count > 1).ToList();
    }
}
// @lc code=end

