/*
 * @lc app=leetcode id=1376 lang=java
 *
 * [1376] Time Needed to Inform All Employees
 */

// @lc code=start
class Solution {
    public int numOfMinutes(int n, int headID, int[] manager, int[] informTime) {
        int[] time = new int[n];
        for (int i = 0; i < n; ++i) {
            time[i] = -1;
        }
        time[headID] = 0;
        int ret = 0;
        for (int i = 0; i < n; ++i) {
            ret = Math.max(calc(i, time, manager, informTime), ret);
        }
        return ret;
    }

    private static int calc(int curr, int[] time, int[] manager, int[] informTime) {
        if (time[curr] != -1) {
            return time[curr];
        }
        time[curr] = informTime[manager[curr]] + calc(manager[curr], time, manager, informTime);
        return time[curr];
    }
}
// @lc code=end

