/*
 * @lc app=leetcode id=1154 lang=csharp
 *
 * [1154] Day of the Year
 */

using System.Linq;

// @lc code=start
public class Solution {

    private static int[] Days = new int[] {
        31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31
    };

    public int DayOfYear(string date) {
        var parsed = date
            .Split('-')
            .Select(int.Parse)
            .ToArray();
        int ret = parsed[2];
        for (int i = 1; i < parsed[1]; ++i) {
            ret += Days[i - 1];
        }
        if (parsed[1] > 2 && parsed[0] % 4 == 0 && (parsed[0] % 400 == 0 || parsed[0] % 100 != 0)) {
            ++ret;
        }
        return ret;
    }
}
// @lc code=end

