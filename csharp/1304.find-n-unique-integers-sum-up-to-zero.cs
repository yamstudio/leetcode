/*
 * @lc app=leetcode id=1304 lang=csharp
 *
 * [1304] Find N Unique Integers Sum up to Zero
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int[] SumZero(int n) {
        var ret = Enumerable
            .Range(2, n / 2 * 2)
            .Select(x => x % 2 == 0 ? x / 2 : -x / 2);
        if (n % 2 == 0) {
            return ret.ToArray();
        }
        return ret.Append(0).ToArray();
    }
}
// @lc code=end

