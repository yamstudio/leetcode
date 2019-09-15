/*
 * @lc app=leetcode id=409 lang=csharp
 *
 * [409] Longest Palindrome
 */

using System.Linq;

public class Solution {
    public int LongestPalindrome(string s) {
        int ret = 0;
        long count = 0;
        foreach (int x in s.Select(c => (c >= 'a' ? ((int) c - (int) 'a') : ((int) c - (int) 'A' + 26)))) {
            long mask = 1L << x;
            if ((mask & count) != 0) {
                ret += 2;
            }
            count ^= mask;
        }
        return ret + (count == 0 ? 0 : 1);
    }
}

