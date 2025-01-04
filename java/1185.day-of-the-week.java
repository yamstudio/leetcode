/*
 * @lc app=leetcode id=1185 lang=java
 *
 * [1185] Day of the Week
 */

// @lc code=start
class Solution {
    private static final int[] DAY_COUNTS = new int[] {
        31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31
    };

    private static final String[] DAYS = new String[] {
        "Friday", "Saturday", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday"
    };

    public String dayOfTheWeek(int day, int month, int year) {
        int delta = day - 1;
        for (int m = 1; m < month; ++m) {
            delta += DAY_COUNTS[m - 1];
        }
        if (month > 2 && year % 4 == 0 && year != 2100) {
            ++delta;
        }
        delta += (year - 1971) * 365 + (year - 1969) / 4;
        return DAYS[delta % 7];
    }
}
// @lc code=end

