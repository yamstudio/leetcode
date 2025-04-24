/*
 * @lc app=leetcode id=1616 lang=java
 *
 * [1616] Split Two Strings to Make Palindrome
 */

// @lc code=start
class Solution {
    public boolean checkPalindromeFormation(String a, String b) {
        return check(a, b) || check(b, a);
    }

    private static boolean check(String a, String b) {
        int n = a.length();
        for (int i = 0; i * 2 < n - 1; ++i) {
            if (a.charAt(i) != b.charAt(n - 1 - i)) {
                return isPalindrome(a, i, n - 1 - i) || isPalindrome(b, i, n - 1 - i);
            }
        }
        return true;
    }

    private static boolean isPalindrome(String s, int l, int r) {
        while (l < r && s.charAt(l) == s.charAt(r)) {
            ++l;
            --r;
        }
        return l >= r;
    }
}
// @lc code=end

