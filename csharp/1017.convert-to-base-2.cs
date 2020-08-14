/*
 * @lc app=leetcode id=1017 lang=csharp
 *
 * [1017] Convert to Base -2
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public string BaseNeg2(int N) {
        if (N == 0) {
            return "0";
        }
        var ret = new LinkedList<char>();
        while (N != 0) {
            ret.AddFirst((char)((int)'0' + (N & 1)));
            N = -(N >> 1);
        }
        return new string(ret.ToArray());
    }
}
// @lc code=end

