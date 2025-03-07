/*
 * @lc app=leetcode id=1419 lang=java
 *
 * [1419] Minimum Number of Frogs Croaking
 */

// @lc code=start
class Solution {
    public int minNumberOfFrogs(String croakOfFrogs) {
        int n = croakOfFrogs.length(), c = 0, r = 0, o = 0, a = 0, ret = 0, sim = 0;
        for (int i = 0; i < n; ++ i) {
            char t = croakOfFrogs.charAt(i);
            if (t == 'c') {
                ++c;
                ++sim;
                ret = Math.max(sim, ret);
            } else if (t == 'r') {
                if (--c < 0) {
                    return -1;
                }
                ++r;
            } else if (t == 'o') {
                if (--r < 0) {
                    return -1;
                }
                ++o;
            } else if (t == 'a') {
                if (--o < 0) {
                    return -1;
                }
                ++a;
            } else {
                if (--a < 0) {
                    return -1;
                }
                --sim;
            }
        }
        if (c > 0 || r > 0 || o > 0 || a > 0) {
            return -1;
        }
        return ret;
    }
}
// @lc code=end

