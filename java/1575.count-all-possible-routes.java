/*
 * @lc app=leetcode id=1575 lang=java
 *
 * [1575] Count All Possible Routes
 */

// @lc code=start
class Solution {
    public int countRoutes(int[] locations, int start, int finish, int fuel) {
        int n = locations.length;
        return countRoutes(locations, finish, start, fuel, new Integer[n][fuel + 1]);
    }

    private static int countRoutes(int[] locations, int finish, int curr, int fuel, Integer[][] memo) {
        if (Math.abs(locations[curr] - locations[finish]) > fuel) {
            return 0;
        }
        Integer m = memo[curr][fuel];
        if (m != null) {
            return m;
        }
        int n = locations.length;
        long ret = curr == finish ? 1 : 0;
        for (int next = 0; next < n; ++next) {
            if (next == curr) {
                continue;
            }
            int d = Math.abs(locations[curr] - locations[next]);
            if (d > fuel) {
                continue;
            }
            ret = (ret + (long)countRoutes(locations, finish, next, fuel - d, memo)) % 1000000007;
        }
        memo[curr][fuel] = (int)ret;
        return (int)ret;
    }
}
// @lc code=end

