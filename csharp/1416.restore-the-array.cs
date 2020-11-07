/*
 * @lc app=leetcode id=1416 lang=csharp
 *
 * [1416] Restore The Array
 */

using System.Linq;

// @lc code=start
public class Solution {

    private static int NumberOfArrays(string s, int k, int i, int[] memo) {
        if (i == s.Length) {
            return 1;
        }
        if (s[i] == '0') {
            return 0;
        }
        if (memo[i] >= 0) {
            return memo[i];
        }
        int ret = 0;
        long acc = 0;
        for (int j = i; j < s.Length; ++j) {
            acc = acc * 10 + (long)s[j] - (long)'0';
            if (acc > (long)k) {
                break;
            }
            ret = (ret + NumberOfArrays(s, k, j + 1, memo)) % 1000000007;
        }
        return memo[i] = ret;
    }

    public int NumberOfArrays(string s, int k) {
        return NumberOfArrays(s, k, 0, Enumerable.Repeat(-1, s.Length).ToArray());
    }
}
// @lc code=end

