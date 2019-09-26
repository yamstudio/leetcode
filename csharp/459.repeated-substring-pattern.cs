/*
 * @lc app=leetcode id=459 lang=csharp
 *
 * [459] Repeated Substring Pattern
 */
public class Solution {
    public bool RepeatedSubstringPattern(string s) {
        int n = s.Length;
        for (int i = 1; i <= n / 2; ++i) {
            if (n % i != 0) {
                continue;
            }
            string sub = s.Substring(0, i);
            bool flag = true;
            for (int j = i; j + i <= n; j += i) {
                if (sub != s.Substring(j, i)) {
                    flag = false;
                    break;
                }
            }
            if (flag) {
                return true;
            }
        }
        return false;
    }
}

