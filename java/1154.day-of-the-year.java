/*
 * @lc app=leetcode id=1154 lang=java
 *
 * [1154] Day of the Year
 */

// @lc code=start
class Solution {

    private static int[] DAY_COUNT = new int[] {
        31,
        28,
        31,
        30,
        31,
        30,
        31,
        31,
        30,
        31,
        30,
        31,
    };

    public int dayOfYear(String date) {
        int year = Integer.parseInt(date.substring(0, 4)), month = Integer.parseInt(date.substring(5, 7)), ret = Integer.parseInt(date.substring(8, 10));
        for (int m = 1; m < month; ++m) {
            ret += DAY_COUNT[m - 1];
        }
        if (month >= 3 && year % 4 == 0 && (year % 100 != 0 || year % 400 == 0)) {
            ++ret;
        }
        return ret;
    }
}
// @lc code=end

