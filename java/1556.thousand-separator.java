/*
 * @lc app=leetcode id=1556 lang=java
 *
 * [1556] Thousand Separator
 */

// @lc code=start
class Solution {
    public String thousandSeparator(int n) {
        if (n == 0) {
            return "0";
        }
        StringBuilder sb = new StringBuilder();
        while (n > 0) {
            if ((sb.length() - 3) % 4 == 0) {
                sb.insert(0, '.');
            }
            sb.insert(0, n % 10);
            n /= 10;
        }
        return sb.toString();
    }
}
// @lc code=end

