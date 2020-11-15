/*
 * @lc app=leetcode id=1450 lang=csharp
 *
 * [1450] Number of Students Doing Homework at a Given Time
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int BusyStudent(int[] startTime, int[] endTime, int queryTime) {
        return startTime
            .Zip(endTime, (s, e) => s <= queryTime && e >= queryTime)
            .Count(d => d);
    }
}
// @lc code=end

