 /*
 * @lc app=leetcode id=818 lang=csharp
 *
 * [818] Race Car
 */

using System;

// @lc code=start
public class Solution {

    private static bool GetAOnly(int target, out int val) {
        val = 0;
        while (target != 0 && (target & 1) == 1) {
            ++val;
            target >>= 1;
        }
        if (target != 0) {
            val = int.MaxValue;
            return false;
        }
        return true;
    }

    public int Racecar(int target) {
        int[] dp = new int[target + 1];
        for (int i = 1; i <= target; ++i) {
            int val;
            if (GetAOnly(i, out val)) {
                dp[i] = val;
                continue;
            }
            int j, aCount = 1;
            for (j = 1; j < i; j = (1 << aCount) - 1) {
                int sCount = 0;
                for (int k = 0; k < j; k = (1 << sCount) - 1) {
                    val = Math.Min(val, aCount + sCount + 2 + dp[i - j + k]);
                    ++sCount;
                }
                ++aCount;
            }
            dp[i] = Math.Min(val, aCount + 1 + dp[j - i]);
        }
        return dp[target];
    }
}
// @lc code=end

