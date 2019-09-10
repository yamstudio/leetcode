/*
 * @lc app=leetcode id=392 lang=csharp
 *
 * [392] Is Subsequence
 */
public class Solution {
    public bool IsSubsequence(string s, string t) {
        int m = s.Length, n = t.Length, i = 0, j = 0;
        while (i < m && j < n) {
            if (s[i] == t[j]) {
                ++i;
            }
            ++j;
        }
        return i == m;
    }
}

