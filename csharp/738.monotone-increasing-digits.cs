/*
 * @lc app=leetcode id=738 lang=csharp
 *
 * [738] Monotone Increasing Digits
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int MonotoneIncreasingDigits(int N) {
        var s = N.ToString().Select(c => (int) c - (int) '0').ToArray();
        int len = s.Length, k = len;
        for (int i = len - 1; i > 0; --i) {
            if (s[i - 1] > s[i]) {
                k = i;
                s[i - 1]--;
            }
        }
        for (int i = k; i < len; ++i) {
            s[i] = 9;
        }
        return s.Aggregate((acc, curr) => acc * 10 + curr);
    }
}
// @lc code=end

