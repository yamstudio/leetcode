/*
 * @lc app=leetcode id=1417 lang=java
 *
 * [1417] Reformat The String
 */

// @lc code=start
class Solution {
    public String reformat(String s) {
        int n = s.length();
        StringBuilder sb = new StringBuilder(n);
        int i = 0, j = 0;
        while (i < n && j < n) {
            while (i < n && (s.charAt(i) < 'a' || s.charAt(i) > 'z')) {
                ++i;
            }
            if (i == n) {
                break;
            }
            sb.append(s.charAt(i));
            ++i;
            while (j < n && (s.charAt(j) < '0' || s.charAt(j) > '9')) {
                ++j;
            }
            if (j == n) {
                break;
            }
            sb.append(s.charAt(j));
            ++j;
        }
        boolean lastLetter = sb.length() > 0 && sb.charAt(sb.length() - 1) >= 'a' && sb.charAt(sb.length() - 1) <= 'z';
        if (i == n) {
            while (j < n && (s.charAt(j) < '0' || s.charAt(j) > '9')) {
                ++j;
            }
            if (j < n) {
                if (lastLetter) {
                    sb.append(s.charAt(j));
                } else {
                    sb.insert(0, s.charAt(j));
                }
                ++j;
            }
            while (j < n && (s.charAt(j) < '0' || s.charAt(j) > '9')) {
                ++j;
            }
            if (j < n) {
                if (lastLetter) {
                    sb.insert(0, s.charAt(j));
                } else {
                    return "";
                }
                ++j;
            }
            while (j < n && (s.charAt(j) < '0' || s.charAt(j) > '9')) {
                ++j;
            }
            if (j < n) {
                return "";
            }
            return sb.toString();
        }
        while (i < n && (s.charAt(i) < 'a' || s.charAt(i) > 'z')) {
            ++i;
        }
        if (i < n) {
            if (lastLetter) {
                return "";
            }
            sb.append(s.charAt(i));
            ++i;
        }
        while (i < n && (s.charAt(i) < 'a' || s.charAt(i) > 'z')) {
            ++i;
        }
        if (i < n) {
            return "";
        }
        return sb.toString();
    }
}
// @lc code=end

