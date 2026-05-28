/*
 * @lc app=leetcode id=1750 lang=java
 *
 * [1750] Minimum Length of String After Deleting Similar Ends
 */

// @lc code=start
class Solution {
    public int minimumLength(String s) {
        int n = s.length(), l = 0, r = n - 1;
        while (l < r) {
            char c = s.charAt(l);
            int nr = r;
            while (nr >= 0 && s.charAt(nr) == c) {
                --nr;
            }
            if (nr == r) {
                break;
            }
            int nl = l;
            while (nl < n && s.charAt(nl) == c) {
                ++nl;
            }
            l = nl;
            r = nr;
        }
        return Math.max(0, r - l + 1);
    }
}
// @lc code=end

