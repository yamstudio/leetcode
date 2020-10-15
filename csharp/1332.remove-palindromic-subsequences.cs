/*
 * @lc app=leetcode id=1332 lang=csharp
 *
 * [1332] Remove Palindromic Subsequences
 */

// @lc code=start
public class Solution {
    public int RemovePalindromeSub(string s) {
        int n = s.Length, h = n / 2;
        if (n == 0) {
            return 0;
        }
        for (int i = 0; i < h; ++i) {
            if (s[i] != s[n - i - 1]) {
                return 2;
            }
        }
        return 1;
    }
}
// @lc code=end

