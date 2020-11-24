/*
 * @lc app=leetcode id=1481 lang=csharp
 *
 * [1481] Least Number of Unique Integers after K Removals
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int FindLeastNumOfUniqueInts(int[] arr, int k) {
        var count = arr
            .GroupBy(x => x, (x, a) => a.Count())
            .OrderBy(c => c)
            .ToArray();
        int ret = count.Length;
        foreach (int c in count) {
            if (c > k) {
                break;
            }
            --ret;
            k -= c;
        }
        return ret;
    }
}
// @lc code=end

