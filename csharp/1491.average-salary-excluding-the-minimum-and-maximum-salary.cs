/*
 * @lc app=leetcode id=1491 lang=csharp
 *
 * [1491] Average Salary Excluding the Minimum and Maximum Salary
 */

// @lc code=start
public class Solution {
    public double Average(int[] salary) {
        int total = 0, min = int.MaxValue, max = int.MinValue;
        foreach (var s in salary) {
            total += s;
            if (s > max) {
                max = s;
            }
            if (s < min) {
                min = s;
            }
        }
        return (double)(total - min - max) / (salary.Length - 2);
    }
}
// @lc code=end

