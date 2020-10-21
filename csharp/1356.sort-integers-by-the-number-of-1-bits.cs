/*
 * @lc app=leetcode id=1356 lang=csharp
 *
 * [1356] Sort Integers by The Number of 1 Bits
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int[] SortByBits(int[] arr) {
        return arr
            .OrderBy(x => {
                int ret = 0;
                while (x > 0) {
                    if ((x & 1) == 1) {
                        ++ret;
                    }
                    x >>= 1;
                }
                return ret;
            })
            .ThenBy(x => x)
            .ToArray();
    }
}
// @lc code=end

