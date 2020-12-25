/*
 * @lc app=leetcode id=1611 lang=csharp
 *
 * [1611] Minimum One Bit Operations to Make Integers Zero
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static int MinimumOneBitOperations(int n, IDictionary<int, int> memo) {
        if (n == 0) {
            return 0;
        }
        if (memo.TryGetValue(n, out var ret)) {
            return ret;
        }
        int m = 1;
        while (n >= (m << 1)) {
            m <<= 1;
        }
        ret = m + MinimumOneBitOperations(n ^ m ^ (m >> 1), memo);
        memo[n] = ret;
        return ret;
    }

    public int MinimumOneBitOperations(int n) {
        return MinimumOneBitOperations(n, new Dictionary<int, int>());
    }
}
// @lc code=end

