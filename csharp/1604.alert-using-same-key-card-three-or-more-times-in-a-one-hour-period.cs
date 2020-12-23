/*
 * @lc app=leetcode id=1604 lang=csharp
 *
 * [1604] Alert Using Same Key-Card Three or More Times in a One Hour Period
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public IList<string> AlertNames(string[] keyName, string[] keyTime) {
        var sorted = keyName
            .Zip(keyTime, (n, t) => (Name: n, Time: t))
            .GroupBy(t => t.Name, (n, a) => (Name: n, All: a.Select(t => {
                var split = t.Time.Split(':');
                return 60 * int.Parse(split[0]) + int.Parse(split[1]);
            }).OrderBy(t => t).ToArray()));
        var ret = new List<string>();
        foreach (var tuple in sorted) {
            int k = tuple.All.Length;
            for (int i = 2; i < k; ++i) {
                if (tuple.All[i] - tuple.All[i - 2] <= 60) {
                    ret.Add(tuple.Name);
                    break;
                }
            }
        }
        ret.Sort();
        return ret;
    }
}
// @lc code=end

