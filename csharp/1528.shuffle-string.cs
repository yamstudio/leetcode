/*
 * @lc app=leetcode id=1528 lang=csharp
 *
 * [1528] Shuffle String
 */

// @lc code=start
public class Solution {
    public string RestoreString(string s, int[] indices) {
        int n = s.Length;
        char[] ret = new char[n];
        for (int i = 0; i < n; ++i) {
            char c = s[i];
            ret[indices[i]] = c;
        }
        return new string(ret);
    }
}
// @lc code=end

