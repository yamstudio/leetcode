/*
 * @lc app=leetcode id=125 lang=csharp
 *
 * [125] Valid Palindrome
 */
public class Solution {
    public bool IsPalindrome(string s) {
        int left = 0, right = s.Length - 1;
        while (left < right) {
            char lc = s[left];
            if (!Char.IsLetter(lc) && !Char.IsNumber(lc)) {
                ++left;
            } else {
                char rc = s[right];
                if (!Char.IsLetter(rc) && !Char.IsNumber(rc)) {
                    --right;
                } else {
                    if (Char.ToLower(lc) != Char.ToLower(rc)) {
                        return false;
                    }
                    ++left;
                    --right;
                }
            }
        }
        return true;
    }
}

