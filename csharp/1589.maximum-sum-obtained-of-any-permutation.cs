/*
 * @lc app=leetcode id=1589 lang=csharp
 *
 * [1589] Maximum Sum Obtained of Any Permutation
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int MaxSumRangeQuery(int[] nums, int[][] requests) {
        int n = nums.Length;
        int[] count = new int[n];
        foreach (var request in requests) {
            ++count[request[0]];
            if (request[1] < n - 1) {
                --count[request[1] + 1];
            }
        }
        for (int i = 1; i < n; ++i) {
            count[i] += count[i - 1];
        }
        return (int)nums
            .OrderBy(x => x)
            .Zip(count.OrderBy(x => x), (x, c) => ((long)x * (long)c) % 1000000007)
            .Aggregate((acc, x) => (acc + x) % 1000000007);
    }
}
// @lc code=end

