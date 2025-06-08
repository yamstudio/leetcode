/*
 * @lc app=leetcode id=1663 lang=java
 *
 * [1663] Smallest String With A Given Numeric Value
 */

// @lc code=start
class Solution {
    public String getSmallestString(int n, int k) {
        if (k < n || k > 26 * n) {
            return "";
        }
        StringBuilder sb = new StringBuilder(n);
        while (n-- > 0) {
            char c;
            if (n * 26 >= k) {
                c = 'a';
            } else if ((n + 1) * 26 == k) {
                c = 'z';
            } else {
                c = (char)('a' + k - 1 - 26 * n);
            }
            sb.append(c);
            k -= c - 'a' + 1;
        }
        return sb.toString();
    }
}
// @lc code=end

