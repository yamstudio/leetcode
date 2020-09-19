/*
 * @lc app=leetcode id=1223 lang=csharp
 *
 * [1223] Dice Roll Simulation
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static int DieSimulatorRecurse(int curr, int count, int left, int[] rollMax, IDictionary<(int Curr, int Count, int Left), int> memo) {
        if (left == 0) {
            return 1;
        }
        var key = (Curr: curr, Count: count, Left: left);
        if (memo.TryGetValue(key, out int ret)) {
            return ret;
        }
        ret = 0;
        for (int i = 0; i < 6; ++i) {
            if (curr == i) {
                if (count == rollMax[i]) {
                    continue;
                }
                ret = (ret + DieSimulatorRecurse(curr, count + 1, left - 1, rollMax, memo)) % 1000000007;
            } else {
                ret = (ret + DieSimulatorRecurse(i, 1, left - 1, rollMax, memo)) % 1000000007;
            }
        }
        memo[key] = ret;
        return ret;
    }

    public int DieSimulator(int n, int[] rollMax) {
        return DieSimulatorRecurse(-1, 0, n, rollMax, new Dictionary<(int Curr, int Count, int Left), int>());
    }
}
// @lc code=end

