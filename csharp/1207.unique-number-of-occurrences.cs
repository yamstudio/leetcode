/*
 * @lc app=leetcode id=1207 lang=csharp
 *
 * [1207] Unique Number of Occurrences
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public bool UniqueOccurrences(int[] arr) {
        var occ = arr
            .GroupBy(x => x, (int key, IEnumerable<int> all) => all.Count());
        var set = new HashSet<int>();
        foreach (var o in occ) {
            if (!set.Add(o)) {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

