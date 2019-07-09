/*
 * @lc app=leetcode id=58 lang=csharp
 *
 * [58] Length of Last Word
 */
public class Solution {
    public int LengthOfLastWord(string s) {
        int d, n = s.Length - 1;
        while (n >= 0 && s[n] == ' ') {
            --n;
        }
        d = n;
        while (d >= 0 && s[d] != ' ') {
            --d;
        }
        return n - d;
    }
}

