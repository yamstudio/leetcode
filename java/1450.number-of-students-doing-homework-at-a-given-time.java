/*
 * @lc app=leetcode id=1450 lang=java
 *
 * [1450] Number of Students Doing Homework at a Given Time
 */

// @lc code=start
class Solution {
    public int busyStudent(int[] startTime, int[] endTime, int queryTime) {
        int ret = 0, n = startTime.length;
        for (int i = 0; i < n; ++i) {
            if (startTime[i] <= queryTime && queryTime <= endTime[i]) {
                ++ret;
            }
        }
        return ret;
    }
}
// @lc code=end

