/*
 * @lc app=leetcode id=1185 lang=csharp
 *
 * [1185] Day of the Week
 */

// @lc code=start
public class Solution {

    private static int[] Days = new int[] {
        31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31
    };

    private string[] Names = new string[] {
        "Friday", "Saturday", "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday"
    };

    public string DayOfTheWeek(int day, int month, int year) {
        int delta = day - 1;
        for (int i = 1; i < month; ++i) {
            delta += Days[i - 1];
        }
        if (month > 2 && year % 4 == 0 && (year % 400 == 0 || year % 100 != 0)) {
            ++delta;
        }
        delta += (year - 1971) * 365 + (year - 1969) / 4;
        return Names[delta % 7];
    }
}
// @lc code=end

