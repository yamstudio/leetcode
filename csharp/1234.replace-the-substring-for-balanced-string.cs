/*
 * @lc app=leetcode id=1234 lang=csharp
 *
 * [1234] Replace the Substring for Balanced String
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int BalancedString(string s) {
        var count = new Dictionary<char, int>(4);
        int n = s.Length, ret = n, t = n / 4, l = 0, r = 0;
        count['Q'] = -t;
        count['W'] = -t;
        count['E'] = -t;
        count['R'] = -t;
        foreach (var c in s) {
            ++count[c];
        }
        while (l <= r) {
            if (count.Values.All(x => x <= 0)) {
                ret = Math.Min(ret, r - l);
                count[s[l++]]++;
            } else {
                if (r >= n) {
                    break;
                }
                count[s[r++]]--;
            }
        }
        return ret;
    }
}
// @lc code=end

