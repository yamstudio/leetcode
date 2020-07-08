/*
 * @lc app=leetcode id=917 lang=csharp
 *
 * [917] Reverse Only Letters
 */

using System;

// @lc code=start
public class Solution {
    public string ReverseOnlyLetters(string S) {
        int n = S.Length, l = 0, r = n - 1;
        char[] ret = new char[n];
        while (l <= r) {
            char cl = S[l];
            if (!Char.IsLetter(cl)) {
                ret[l++] = cl;
                continue;
            }
            char cr = S[r];
            if (!Char.IsLetter(cr)) {
                ret[r--] = cr;
                continue;
            }
            ret[l++] = cr;
            ret[r--] = cl;
        }
        return new string(ret);
    }
}
// @lc code=end

