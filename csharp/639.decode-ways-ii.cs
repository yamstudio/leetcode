/*
 * @lc app=leetcode id=639 lang=csharp
 *
 * [639] Decode Ways II
 */

// @lc code=start
public class Solution {
    public int NumDecodings(string s) {
        long pv = 1, cv = 1;
        char p = '9';
        foreach (char c in s) {
            long tmp;
            if (c == '*') {
                tmp = (cv * 9) % 1000000007;
                if (p == '1' || p == '*') {
                    tmp = (pv * 9 + tmp) % 1000000007;
                }
                if (p == '2' || p == '*') {
                    tmp = (pv * 6 + tmp) % 1000000007;
                }
            } else if (c != '0') {
                tmp = cv;
                if (p == '1' || p == '*') {
                    tmp = (pv + tmp) % 1000000007;
                }
                if (c <= '6' && (p == '2' || p == '*')) {
                    tmp = (pv + tmp) % 1000000007;
                }
            } else {
                tmp = 0;
                if (p == '0') {
                    return 0;
                }
                if (p == '1' || p == '*') {
                    tmp = (pv + tmp) % 1000000007;
                }
                if (p == '2' || p == '*') {
                    tmp = (pv + tmp) % 1000000007;
                }
            }
            pv = cv;
            cv = tmp;
            p = c;
        }
        return (int) cv;
    }
}
// @lc code=end

