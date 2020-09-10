/*
 * @lc app=leetcode id=1163 lang=csharp
 *
 * [1163] Last Substring in Lexicographical Order
 */

// @lc code=start
public class Solution {
    public string LastSubstring(string s) {
        int n = s.Length, i = 0, ni = 1, l = 0;
        while (ni + l < n) {
            char ci = s[i + l], cni = s[ni + l];
            if (ci == cni) {
                ++l;
                continue;
            }
            if (ci > cni) {
                ni = ni + l + 1;
                l = 0;
            } else {
                i = ni;
                ni++;
                l = 0;
            }
        }
        return s.Substring(i);
    }
}
// @lc code=end

