/*
 * @lc app=leetcode id=1432 lang=java
 *
 * [1432] Max Difference You Can Get From Changing an Integer
 */

// @lc code=start
class Solution {
    public int maxDiff(int num) {
        String str = String.valueOf(num), max = str;
        int n = str.length();
        for (int i = 0; i < n; ++i) {
            char c = str.charAt(i);
            if (c == '9') {
                continue;
            }
            max = str.replace(c, '9');
            break;
        }
        if (str.charAt(0) != '1') {
            return Integer.parseInt(max) - Integer.parseInt(str.replace(str.charAt(0), '1'));
        }
        String min = str;
        for (int i = 1; i < n; ++i) {
            char c = str.charAt(i);
            if (c == '0' || c == '1') {
                continue;
            }
            min = str.replace(c, '0');
            break;
        }
        return Integer.parseInt(max) - Integer.parseInt(min);
    }
}
// @lc code=end

