/*
 * @lc app=leetcode id=1090 lang=csharp
 *
 * [1090] Largest Values From Labels
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int LargestValsFromLabels(int[] values, int[] labels, int num_wanted, int use_limit) {
        return values
            .Zip(labels, (int value, int label) => (Label: label, Value: value))
            .OrderByDescending(t => t.Value)
            .GroupBy(t => t.Label, (int label, IEnumerable<(int Label, int Value)> all) => all.Take(use_limit).Select(t => t.Value))
            .SelectMany(all => all)
            .OrderByDescending(x => x)
            .Take(num_wanted)
            .Sum();
    }
}
// @lc code=end

