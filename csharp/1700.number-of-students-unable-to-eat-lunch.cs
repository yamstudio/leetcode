/*
 * @lc app=leetcode id=1700 lang=csharp
 *
 * [1700] Number of Students Unable to Eat Lunch
 */

// @lc code=start
public class Solution {
    public int CountStudents(int[] students, int[] sandwiches) {
        var count = new int[] { 0, 0 };
        int n = students.Length, t = 0;
        foreach (int s in students) {
            ++count[s];
        }
        for (; t < n && count[sandwiches[t]] > 0; ++t) {
            --count[sandwiches[t]];
        }
        return n - t;
    }
}
// @lc code=end

