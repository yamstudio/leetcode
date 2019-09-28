/*
 * @lc app=leetcode id=464 lang=csharp
 *
 * [464] Can I Win
 */

using System.Collections.Generic;

public class Solution {

    private static bool CanIWinRecurse(int max, int total, int used, IDictionary<int, bool> canWin) {
        if (canWin.ContainsKey(used)) {
            return canWin[used];
        }
        for (int i = 0; i < max; ++i) {
            int mask = 1 << i;
            if ((mask & used) == 0 && (i + 1 >= total || !CanIWinRecurse(max, total - i - 1, used | mask, canWin))) {
                return (canWin[used] = true);
            }
        }
        return (canWin[used] = false);
    }

    public bool CanIWin(int maxChoosableInteger, int desiredTotal) {
        if (maxChoosableInteger >= desiredTotal) {
            return true;
        }
        if (maxChoosableInteger * (1 + maxChoosableInteger) / 2 < desiredTotal) {
            return false;
        }
        return CanIWinRecurse(maxChoosableInteger, desiredTotal, 0, new Dictionary<int, bool>());
    }
}

