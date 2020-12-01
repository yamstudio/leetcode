/*
 * @lc app=leetcode id=1513 lang=csharp
 *
 * [1513] Number of Substrings With Only 1s
 */

// @lc code=start
public class Solution {
    public int NumSub(string s) {
        int n = s.Length, ret = 0;
        for (int i = 0; i < n;) {
            if (s[i] == '0') {
                ++i;
                continue;
            }
            int ni = i + 1;
            while (ni < n && s[ni] == '1') {
                ++ni;
            }
            ret = (ret + (int)(((long)(ni - i) * (long)(ni - i + 1) / 2) % 1000000007)) % 1000000007;
            i = ni + 1;
        }
        return ret;
    }
}
// @lc code=end

