/*
 * @lc app=leetcode id=896 lang=csharp
 *
 * [896] Monotonic Array
 */

using System.Linq;

// @lc code=start
public class Solution {
    public bool IsMonotonic(int[] A) {
        var diffs =  A
            .Skip(1)
            .Zip(A, (curr, prev) => curr - prev)
            .ToArray();
        return diffs.All(diff => diff >= 0) || diffs.All(diff => diff <= 0);
    }
}
// @lc code=end

