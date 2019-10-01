/*
 * @lc app=leetcode id=479 lang=csharp
 *
 * [479] Largest Palindrome Product
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    public int LargestPalindrome(int n) {
        long max = (long) Math.Pow(10, (double) n) - 1, min = max / 10;
        for (long i = max; i > min; --i) {
            long num = long.Parse($"{i}{new string(i.ToString().Reverse().ToArray())}");
            for (long j = max; j * j > num; --j) {
                if (num % j == 0) {
                    return (int) (num % 1337);
                }
            }
        }
        return 9;

    }
}
// @lc code=end

