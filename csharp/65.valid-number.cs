/*
 * @lc app=leetcode id=65 lang=csharp
 *
 * [65] Valid Number
 */
public class Solution {
    public bool IsNumber(string s) {
        int i = 0, n = s.Length;
        bool nflag = false;
        while (i < n && s[i] == ' ') {
            ++i;
        }
        if (i == n) {
            return false;
        }
        if (s[i] == '-' || s[i] == '+') {
            ++i;
            if (i == n) {
                return false;
            }
        }
        while (i < n && s[i] >= '0' && s[i] <= '9') {
            ++i;
            nflag = true;
        }
        if (i == n) {
            return nflag;
        }
        if (s[i] == '.') {
            ++i;
            while (i < n && s[i] >= '0' && s[i] <= '9') {
                ++i;
                nflag = true;
            }
            if (i == n) {
                return nflag;
            }
        }
        if (s[i] == 'e') {
            ++i;
            if (i < n && (s[i] == '-' || s[i] == '+')) {
                ++i;
            }
            int j = i;
            while (i < n && s[i] >= '0' && s[i] <= '9') {
                ++i;
            }
            if (i == j) {
                return false;
            }
        }
        while (i < n && s[i] == ' ') {
            ++i;
        }
        return nflag && i == n;
    }
}

