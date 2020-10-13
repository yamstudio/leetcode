/*
 * @lc app=leetcode id=1328 lang=csharp
 *
 * [1328] Break a Palindrome
 */

// @lc code=start
public class Solution {
    public string BreakPalindrome(string palindrome) {
        int n = palindrome.Length, h = n / 2, i;
        if (n == 1) {
            return "";
        }
        for (i = 0; i < h && palindrome[i] == 'a'; ++i);
        var ret = palindrome.ToCharArray();
        if (i == h) {
            ret[n - 1] = 'b';
        } else {
            ret[i] = 'a';
        }
        return new string(ret);
    }
}
// @lc code=end

