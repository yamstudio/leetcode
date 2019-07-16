/*
 * @lc app=leetcode id=91 lang=csharp
 *
 * [91] Decode Ways
 */
public class Solution {
    public int NumDecodings(string s) {
        if (s.Length == 0) {
            return 0;
        }
        int p = 1, ret = s[0] == '0' ? 0 : 1;
        for (int i = 1; i < s.Length; ++i) {
            int tmp = ret;
            if (s[i] == '0') {
                ret = 0;
            }
            if (s[i - 1] == '1' || (s[i - 1] == '2' && s[i] <= '6')) {
                ret += p;
            }
            p = tmp;
        }
        return ret;
    }
}

