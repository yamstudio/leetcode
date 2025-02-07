/*
 * @lc app=leetcode id=1328 lang=java
 *
 * [1328] Break a Palindrome
 */

// @lc code=start
class Solution {
    public String breakPalindrome(String palindrome) {
        int n = palindrome.length();
        if (n == 1) {
            return "";
        }
        int i;
        for (i = 0; i * 2 < n - 1&& palindrome.charAt(i) == 'a'; ++i);
        StringBuilder sb = new StringBuilder(palindrome);
        if (i * 2 >= n - 1) {
            sb.replace(n - 1, n, "b");
        } else {
            sb.replace(i, i + 1, "a");
        }
        return sb.toString();
    }
}
// @lc code=end

