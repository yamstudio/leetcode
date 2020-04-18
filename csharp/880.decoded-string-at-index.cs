/*
 * @lc app=leetcode id=880 lang=csharp
 *
 * [880] Decoded String at Index
 */

// @lc code=start
public class Solution {
    public string DecodeAtIndex(string S, int K) {
        long count = 0, l = (long)K;
        int i;
        for (i = 0; count < l; ++i) {
            char c = S[i];
            if ('a' <= c && c <= 'z') {
                ++count;
            } else {
                count *= (long)((int)c - (int)'0');
            }
        }
        for (--i; i >= 0; --i) {
            char c = S[i];
            if ('a' <= c && c <= 'z') {
                if (l % count == 0) {
                    return new string(c, 1);
                }
                --count;
            } else {
                count /= (long)((int)c - (int)'0');
                l %= count;
            }
        }
        return "";
    }
}
// @lc code=end

