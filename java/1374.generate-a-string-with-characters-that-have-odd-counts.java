/*
 * @lc app=leetcode id=1374 lang=java
 *
 * [1374] Generate a String With Characters That Have Odd Counts
 */

// @lc code=start
class Solution {
    public String generateTheString(int n) {
        StringBuilder sb = new StringBuilder(n);
        char c = 'a';
        while (sb.length() < n) {
            int k = n - sb.length();
            while (k % 2 == 0) {
                k /= 2;
            }
            while (k-- > 0) {
                sb.append(c);
            }
            ++c;
        }
        return sb.toString();
    }
}
// @lc code=end

