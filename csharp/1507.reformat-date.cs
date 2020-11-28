/*
 * @lc app=leetcode id=1507 lang=csharp
 *
 * [1507] Reformat Date
 */

// @lc code=start
public class Solution {

    private static string[] Months = new string[] {
        "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
    };

    public string ReformatDate(string date) {
        var split = date.Split(' ');
        int day = 0;
        foreach (char c in split[0]) {
            if (c >= '0' && c <= '9') {
                day = day * 10 + (int)c - (int)'0';
            } else {
                break;
            }
        }
        int month = 0;
        for (int i = 0; i < 12; ++i) {
            if (split[1] == Months[i]) {
                month = 1 + i;
                break;
            }
        }
        return $"{split[2]}-{month.ToString("D2")}-{day.ToString("D2")}";
    }
}
// @lc code=end

