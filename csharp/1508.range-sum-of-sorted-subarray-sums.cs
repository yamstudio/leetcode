/*
 * @lc app=leetcode id=1508 lang=csharp
 *
 * [1508] Range Sum of Sorted Subarray Sums
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int RangeSum(int[] nums, int n, int left, int right) {
        IList<int> prefix = new List<int>(), all = new List<int>();
        int acc = 0;
        foreach (int x in nums) {
            acc += x;
            foreach (int p in prefix) {
                all.Add(acc - p);
            }
            all.Add(acc);
            prefix.Add(acc);
        }
        return all
            .OrderBy(x => x)
            .Skip(left - 1)
            .Take(right - left + 1)
            .Aggregate((acc, x) => (acc + x) % 1000000007);
    }
}
// @lc code=end

