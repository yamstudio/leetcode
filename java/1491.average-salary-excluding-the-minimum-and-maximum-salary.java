/*
 * @lc app=leetcode id=1491 lang=java
 *
 * [1491] Average Salary Excluding the Minimum and Maximum Salary
 */

// @lc code=start
class Solution {
    public double average(int[] salary) {
        int min = Integer.MAX_VALUE, max = Integer.MIN_VALUE, sum = 0;
        for (int s : salary) {
            min = Math.min(min, s);
            max = Math.max(max, s);
            sum += s;
        }
        return (double)(sum - min - max) / (salary.length - 2);
    }
}
// @lc code=end

