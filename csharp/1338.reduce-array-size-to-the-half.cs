/*
 * @lc app=leetcode id=1338 lang=csharp
 *
 * [1338] Reduce Array Size to The Half
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int MinSetSize(int[] arr) {
        int t = arr.Length / 2, ret = 0;
        foreach (int curr in arr
            .GroupBy(x => x, (x, a) => a.Count())
            .OrderByDescending(c => c)) {
            t -= curr;
            ++ret;
            if (t <= 0) {
                break;
            }
        }
        return ret;
    }
}
// @lc code=end

