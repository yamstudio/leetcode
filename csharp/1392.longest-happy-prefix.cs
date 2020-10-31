/*
 * @lc app=leetcode id=1392 lang=csharp
 *
 * [1392] Longest Happy Prefix
 */

// @lc code=start
public class Solution {
    public string LongestPrefix(string s) {
        int n = s.Length, p = 0;
        int[] k = new int[n];
        for (int i = 1; i < n;) {
            if (s[i] == s[p]) {
                k[i++] = ++p;
            } else {
                if (p == 0) {
                    ++i;
                } else {
                    p = k[p - 1];
                }
            }
        }
        return s.Substring(0, k[n - 1]);
    }
}
// @lc code=end

