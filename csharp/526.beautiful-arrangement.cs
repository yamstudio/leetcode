/*
 * @lc app=leetcode id=526 lang=csharp
 *
 * [526] Beautiful Arrangement
 */

// @lc code=start
public class Solution {

    private static int CountArrangementRecurse(int n, int used, int i) {
        if (i > n) {
            return 1;
        }
        int ret = 0, mask = 1;
        for (int j = 1; j <= n; ++j) {
            if ((used & mask) == 0 && (i % j == 0 || j % i == 0)) {
                used |= mask;
                ret += CountArrangementRecurse(n, used, i + 1);
                used &= ~mask;
            }
            mask <<= 1;
        }
        return ret;
    }

    public int CountArrangement(int N) {
        return CountArrangementRecurse(N, 0, 1);
    }
}
// @lc code=end

