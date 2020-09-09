/*
 * @lc app=leetcode id=1156 lang=csharp
 *
 * [1156] Swap For Longest Repeated Character Substring
 */

using System;

// @lc code=start
public class Solution {
    public int MaxRepOpt1(string text) {
        int n = text.Length, ret;
        int[] count = new int[n], total = new int[26];
        count[0] = 1;
        total[(int)text[0] - (int)'a'] = 1;
        for (int i = 1; i < n; ++i) {
            if (text[i] == text[i - 1]) {
                count[i] = count[i - 1] + 1;
            } else {
                count[i] = 1;
            }
            ++total[(int)text[i] - (int)'a'];
        }
        ret = count[n - 1] + (total[(int)text[n - 1] - (int)'a'] > count[n - 1] ? 1 : 0);
        for (int i = n - 2; i >= 0; --i) {
            if (text[i] == text[i + 1]) {
                count[i] = count[i + 1];
            } else {
                if (count[i] == total[(int)text[i] - (int)'a']) {
                    ret = Math.Max(ret, count[i]);
                } else {
                    ret = Math.Max(ret, 1 + count[i]);
                }
            }
        }
        for (int i = 1; i < n - 1; ++i) {
            if (text[i] != text[i - 1] && text[i] != text[i + 1] && text[i - 1] == text[i + 1]) {
                int b = count[i - 1] + count[i + 1];
                if (total[(int)text[i - 1] - (int)'a'] > b) {
                    ++b;
                }
                ret = Math.Max(b, ret);
            }
        }
        return ret;
    }
}
// @lc code=end

