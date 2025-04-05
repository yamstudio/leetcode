/*
 * @lc app=leetcode id=1544 lang=java
 *
 * [1544] Make The String Great
 */

// @lc code=start
class Solution {
    public String makeGood(String s) {
        int n = s.length();
        StringBuilder sb = new StringBuilder(n);
        for (int i = 0; i < n; ++i) {
            char c = s.charAt(i);
            if (Character.isUpperCase(c) && sb.length() > 0 && sb.charAt(sb.length() - 1) == Character.toLowerCase(c)) {
                sb.deleteCharAt(sb.length() - 1);
            } else if (Character.isLowerCase(c) && sb.length() > 0 && sb.charAt(sb.length() - 1) == Character.toUpperCase(c)) {
                sb.deleteCharAt(sb.length() - 1);
            } else {
                sb.append(c);
            }
        }
        return sb.toString();
    }
}
// @lc code=end

