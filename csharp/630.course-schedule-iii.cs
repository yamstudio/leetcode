/*
 * @lc app=leetcode id=630 lang=csharp
 *
 * [630] Course Schedule III
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int ScheduleCourse(int[][] courses) {
        SortedSet<(int, int, int)> sorted = new SortedSet<(int, int, int)>(Comparer<(int, int, int)>.Create((a, b) => a.Item1 == b.Item1 ? a.Item3.CompareTo(b.Item3) : a.Item1.CompareTo(b.Item1)));
        int time = 0;
        foreach (var course in courses.Select((course, i) => (course[0], course[1], i)).OrderBy(c => c.Item2)) {
            sorted.Add(course);
            time += course.Item1;
            if (time > course.Item2) {
                var max = sorted.Max;
                time -= max.Item1;
                sorted.Remove(max);
            }
        }
        return sorted.Count;
    }
}
// @lc code=end

