/*
 * @lc app=leetcode id=1360 lang=csharp
 *
 * [1360] Number of Days Between Two Dates
 */

using System;

// @lc code=start
public class Solution {

    private static int[] Days = new int[] {
        0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334
    };
    
    private static int GetDays(string date) {
        var split = date.Split('-');
        int y = int.Parse(split[0]),
            m = int.Parse(split[1]),
            d = int.Parse(split[2]),
            dy = (y - 1971) * 365 + (y - 1969) / 4,
            dm = Days[m - 1] + (m > 2 && y % 4 == 0 && (y % 100 != 0 || y % 400 == 0) ? 1 : 0);
        return dy + dm + d;
    }
    
    public int DaysBetweenDates(string date1, string date2) {
        return Math.Abs(GetDays(date2) - GetDays(date1));
    }
}
// @lc code=end

