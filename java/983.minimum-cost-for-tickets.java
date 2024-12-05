/*
 * @lc app=leetcode id=983 lang=java
 *
 * [983] Minimum Cost For Tickets
 */
import java.util.Arrays;
import java.util.Set;

// @lc code=start
import static java.util.stream.Collectors.toUnmodifiableSet;

class Solution {
    public int mincostTickets(int[] days, int[] costs) {
        int max = days[days.length - 1];
        int[] dp = new int[max + 1];
        Set<Integer> allDays = Arrays.stream(days).boxed().collect(toUnmodifiableSet());
        for (int i = 1; i <= max; ++i) {
            if (!allDays.contains(i)) {
                dp[i] = dp[i - 1];
                continue;
            }
            dp[i] = Math.min(dp[i - 1] + costs[0], Math.min(dp[Math.max(0, i - 7)] + costs[1], dp[Math.max(0, i - 30)] + costs[2]));
        }
        return dp[max];
    }
}
// @lc code=end

