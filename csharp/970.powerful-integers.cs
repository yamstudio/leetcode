/*
 * @lc app=leetcode id=970 lang=csharp
 *
 * [970] Powerful Integers
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public IList<int> PowerfulIntegers(int x, int y, int bound) {
        var ret = new HashSet<int>();
        for (int a = 1; a < bound; a *= x) {
            for (int b = 1; b + a <= bound; b *= y) {
                ret.Add(a + b);
                if (y == 1) {
                    break;
                }
            }
            if (x == 1) {
                break;
            }
        }
        return ret.ToList();
    }
}
// @lc code=end

