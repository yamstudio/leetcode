/*
 * @lc app=leetcode id=1122 lang=csharp
 *
 * [1122] Relative Sort Array
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int[] RelativeSortArray(int[] arr1, int[] arr2) {
        var map = arr2
            .Select((int x, int i) => (Key: x, Index: i))
            .ToDictionary(t => t.Key, t => t.Index);
        return arr1
            .OrderBy(x => map.TryGetValue(x, out int i) ? i : (2000 + x))
            .ToArray();
    }
}
// @lc code=end

