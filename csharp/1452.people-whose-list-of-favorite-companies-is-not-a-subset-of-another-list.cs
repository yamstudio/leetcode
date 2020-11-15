/*
 * @lc app=leetcode id=1452 lang=csharp
 *
 * [1452] People Whose List of Favorite Companies Is Not a Subset of Another List
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public IList<int> PeopleIndexes(IList<IList<string>> favoriteCompanies) {
        int n = favoriteCompanies.Count;
        var ret = new List<int>();
        var sets = favoriteCompanies.Select(p => new HashSet<string>(p)).ToArray();
        for (int i = 0; i < n; ++i) {
            bool flag = false;
            var set = sets[i];
            for (int j = 0; j < n && !flag; ++j) {
                if (set.Count >= sets[j].Count) {
                    continue;
                }
                flag = set.IsSubsetOf(sets[j]);
            }
            if (!flag) {
                ret.Add(i);
            }
        }
        return ret;
    }
}
// @lc code=end

