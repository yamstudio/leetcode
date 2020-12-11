/*
 * @lc app=leetcode id=1556 lang=csharp
 *
 * [1556] Thousand Separator
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public string ThousandSeparator(int n) {
        if (n == 0) {
            return "0";
        }
        var ret = new List<char>();
        int k = 0;
        while (n > 0) {
            ret.Add((char)((int)'0' + n % 10));
            n /= 10;
            if (++k == 3) {
                k = 0;
                ret.Add('.');
            }
        }
        return new string(ret.Reverse<char>().Skip(k == 0 ? 1 : 0).ToArray());
    }
}
// @lc code=end

