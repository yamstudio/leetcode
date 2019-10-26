/*
 * @lc app=leetcode id=564 lang=csharp
 *
 * [564] Find the Closest Palindrome
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    public string NearestPalindromic(string n) {
        int len = n.Length;
        long num = long.Parse(n), half = long.Parse(n.Substring(0, (len + 1) / 2));
        return Enumerable
            .Range(-1, 3)
            .Select(delta => {
                string prefix = (half + (long) delta).ToString();
                string suffix = new string(prefix.Reverse().Skip(len % 2).ToArray());
                return long.Parse($"{prefix}{suffix}");
            })
            .Where(x => x != num)
            .Union(new long[] { (long) Math.Pow(10.0, (double) len) + 1L, (long) Math.Pow(10.0, (double) len - 1.0) - 1L })
            .Aggregate((long.MaxValue, long.MaxValue), (ret, curr) => {
                long diff = Math.Abs(num - curr);
                return (diff < ret.Item1 || (diff == ret.Item1 && curr < ret.Item2)) ? (diff, curr) : ret;
            }, ret => ret.Item2)
            .ToString();
    }
}
// @lc code=end

