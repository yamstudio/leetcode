/*
 * @lc app=leetcode id=1291 lang=csharp
 *
 * [1291] Sequential Digits
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public IList<int> SequentialDigits(int low, int high) {
        int len = 0, inc = 0, b = 0, t = low;
        var ret = new List<int>();
        while (t > 0) {
            t /= 10;
            ++len;
            b = b * 10 + len;
            inc = inc * 10 + 1;
        }
        while (b <= high && len <= 9) {
            int c = b;
            while (c <= high && c % 10 != 0) {
                if (c >= low) {
                    ret.Add(c);
                }
                c += inc;
            }
            ++len;
            b = b * 10 + len;
            inc = inc * 10 + 1;
        }
        return ret;
    }
}
// @lc code=end

