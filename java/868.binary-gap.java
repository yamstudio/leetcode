/*
 * @lc app=leetcode id=868 lang=java
 *
 * [868] Binary Gap
 */

// @lc code=start
class Solution {
    public int binaryGap(int n) {
        int i = 0, p = -1, ret = 0;
        while (n != 0) {
            if ((n & 1) == 1) {
                if (p >= 0) {
                    ret = Math.max(ret, i - p);
                }
                p = i;
            }
            ++i;
            n >>= 1;
        }
        return ret;
    }
}
// @lc code=end

