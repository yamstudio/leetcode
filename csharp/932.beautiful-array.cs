/*
 * @lc app=leetcode id=932 lang=csharp
 *
 * [932] Beautiful Array
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int[] BeautifulArray(int N) {
        int[] ret = new int[] { 1 };
        while (ret.Length < N) {
            ret = Enumerable
                .Concat(
                    ret.Select(x => 2 * x - 1).Where(x => x <= N),
                    ret.Select(x => 2 * x).Where(x => x <= N)
                )
                .ToArray();
        }
        return ret;
    }
}
// @lc code=end

