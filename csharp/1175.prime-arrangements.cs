/*
 * @lc app=leetcode id=1175 lang=csharp
 *
 * [1175] Prime Arrangements
 */

using System;

// @lc code=start
public class Solution {
    public int NumPrimeArrangements(int n) {
        long ret = 1, p = 0;
        for (int i = 2; i <= n; ++i) {
            if (IsPrime(i)) {
                ++p;
            }
        }
        for (int i = 1; i <= p; ++i) {
            ret = (ret * (long)i) % 1000000007;
        }
        for (int i = 1; i <= n - p; ++i) {
            ret = (ret * (long)i) % 1000000007;
        }
        return (int)ret;
    }

    private static bool IsPrime(int x) {
        for (int f = (int)Math.Sqrt((double)x); f >= 2; --f) {
            if (x % f == 0) {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

