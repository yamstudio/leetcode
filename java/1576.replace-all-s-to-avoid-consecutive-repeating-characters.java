/*
 * @lc app=leetcode id=1576 lang=java
 *
 * [1576] Replace All ?'s to Avoid Consecutive Repeating Characters
 */

// @lc code=start
class Solution {
    public String modifyString(String s) {
        int n = s.length();
        StringBuilder sb = new StringBuilder(n);
        char prev = '-';
        for (int i = 0; i < n; ++i) {
            char curr = s.charAt(i);
            if (curr != '?') {
                prev = curr;
                sb.append(curr);
                continue;
            }
            char next = i == n - 1 ? '-' : s.charAt(i + 1);
            if (prev != 'a' && next != 'a') {
                prev = 'a';
            } else if (prev != 'b' && next != 'b') {
                prev = 'b';
            } else {
                prev = 'c';
            }
            sb.append(prev);
        }
        return sb.toString();
    }
}
// @lc code=end

