/*
 * @lc app=leetcode id=1619 lang=csharp
 *
 * [1619] Mean of Array After Removing Some Elements
 */

using System.Linq;

// @lc code=start
public class Solution {
    public double TrimMean(int[] arr) {
        int n = arr.Length;
        return ((double)arr
            .OrderBy(x => x)
            .Skip(n / 20)
            .SkipLast(n / 20)
            .Sum()
        ) / (double)(n / 10 * 9);
    }
}
// @lc code=end

