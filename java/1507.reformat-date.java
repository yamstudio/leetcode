/*
 * @lc app=leetcode id=1507 lang=java
 *
 * [1507] Reformat Date
 */

import java.util.Map;

// @lc code=start

class Solution {

    private static final Map<String, String> MONTHS = Map.ofEntries(
        Map.entry("Jan", "01"),
        Map.entry("Feb", "02"),
        Map.entry("Mar", "03"),
        Map.entry("Apr", "04"),
        Map.entry("May", "05"),
        Map.entry("Jun", "06"),
        Map.entry("Jul", "07"),
        Map.entry("Aug", "08"),
        Map.entry("Sep", "09"),
        Map.entry("Oct", "10"),
        Map.entry("Nov", "11"),
        Map.entry("Dec", "12")
    );

    public String reformatDate(String date) {
        StringBuilder sb = new StringBuilder(10);
        String[] split = date.split(" ", -1);
        sb.append(split[2]);
        sb.append('-');
        sb.append(MONTHS.get(split[1]));
        sb.append('-');
        int day = split[0].charAt(0) - '0';
        char c = split[0].charAt(1);
        if (c >= '0' && c <= '9') {
            day = day * 10 + (c - '0');
        }
        if (day < 10) {
            sb.append('0');
        }
        sb.append(day);
        return sb.toString();
    }
}
// @lc code=end

