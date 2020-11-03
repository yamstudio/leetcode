/*
 * @lc app=leetcode id=1400 lang=csharp
 *
 * [1400] Construct K Palindrome Strings
 */

// @lc code=start
public class Solution {
    public bool CanConstruct(string s, int k) {
        int n = s.Length;
        if (k > n) {
            return false;
        }
        int mask = 0, count = 0;
        foreach (char c in s) {
            mask ^= 1 << ((int)c - (int)'a');
        }
        while (mask != 0) {
            count += mask & 1;
            mask >>= 1;
        }
        return count <= k;
    }
}
// @lc code=end

