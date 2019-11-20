/*
 * @lc app=leetcode id=680 lang=csharp
 *
 * [680] Valid Palindrome II
 */

// @lc code=start
public class Solution {
    public bool ValidPalindrome(string s) {
        int l = 0, r = s.Length - 1;
        while (l < r) {
            if (s[l] != s[r]) {
                return IsPalindrome(s, l + 1, r) || IsPalindrome(s, l, r - 1);
            }
            ++l;
            --r;
        }
        return true;
    }

    private static bool IsPalindrome(string s, int l, int r) {
        while (l < r) {
            if (s[l++] != s[r--]) {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

