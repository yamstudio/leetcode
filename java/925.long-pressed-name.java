/*
 * @lc app=leetcode id=925 lang=java
 *
 * [925] Long Pressed Name
 */

// @lc code=start
class Solution {
    public boolean isLongPressedName(String name, String typed) {
        int m = name.length(), n = typed.length(), i = 0, j = 0;
        while (i < m && j < n) {
            char c = name.charAt(i);
            int count = 0;
            while (i < m && name.charAt(i) == c) {
                ++count;
                ++i;
            }
            while (j < n && typed.charAt(j) == c) {
                --count;
                ++j;
            }
            if (count > 0) {
                return false;
            }
        }
        return i == m && j == n;
    }
}
// @lc code=end

