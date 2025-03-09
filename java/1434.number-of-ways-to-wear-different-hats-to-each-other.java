/*
 * @lc app=leetcode id=1434 lang=java
 *
 * [1434] Number of Ways to Wear Different Hats to Each Other
 */

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

// @lc code=start
class Solution {
    public int numberWays(List<List<Integer>> hats) {
        int n = hats.size();
        Map<Integer, List<Integer>> hatToPeople = new HashMap<>();
        for (int i = 0; i < n; ++i) {
            for (int hat : hats.get(i)) {
                hatToPeople.computeIfAbsent(hat, ignored -> new ArrayList<>()).add(i);
            }
        }
        return numberWays(0, (1 << n) - 1, 0, List.copyOf(hatToPeople.values()), new Integer[1 << n][hatToPeople.size()]);
    }

    private static int numberWays(int curr, int target, int hat, List<List<Integer>> hatToPeople, Integer[][] memo) {
        if (curr == target) {
            return 1;
        }
        if (hat >= hatToPeople.size()) {
            return 0;
        }
        Integer mem = memo[curr][hat];
        if (mem != null) {
            return mem;
        }
        int ret = numberWays(curr, target, hat + 1, hatToPeople, memo);
        for (int p : hatToPeople.get(hat)) {
            if ((curr & (1 << p)) != 0) {
                continue;
            }
            ret = (ret + numberWays(curr | (1 << p), target, hat + 1, hatToPeople, memo)) % 1000000007;
        }
        memo[curr][hat] = ret;
        return ret;
    }
}
// @lc code=end

