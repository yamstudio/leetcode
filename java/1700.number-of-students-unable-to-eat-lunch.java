/*
 * @lc app=leetcode id=1700 lang=java
 *
 * [1700] Number of Students Unable to Eat Lunch
 */

// @lc code=start
class Solution {
    public int countStudents(int[] students, int[] sandwiches) {
        int n = students.length;
        int[] count = new int[2];
        for (int s : students) {
            ++count[s];
        }
        int t;
        for (t = 0; t < n && count[sandwiches[t]] > 0; ++t) {
            --count[sandwiches[t]];
        }
        return n - t;
    }
}
// @lc code=end

