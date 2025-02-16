/*
 * @lc app=leetcode id=1360 lang=java
 *
 * [1360] Number of Days Between Two Dates
 */

// @lc code=start
class Solution {
    private static final int[] DAY_COUNTS = new int[] {
        31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31
    };

    public int daysBetweenDates(String date1, String date2) {
        return Math.abs(delta(date2) - delta(date1));
    }
    
    private static int delta(String date) {
        String[] split = date.split("-");
        int year = Integer.parseInt(split[0]), month = Integer.parseInt(split[1]), day = Integer.parseInt(split[2]), delta = day - 1;
        for (int m = 1; m < month; ++m) {
            delta += DAY_COUNTS[m - 1];
        }
        if (month > 2 && year % 4 == 0 && year != 2100) {
            ++delta;
        }
        delta += (year - 1971) * 365 + (year - 1969) / 4;
        return delta;
    }
}
// @lc code=end

