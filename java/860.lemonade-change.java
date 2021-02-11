/*
 * @lc app=leetcode id=860 lang=java
 *
 * [860] Lemonade Change
 */

// @lc code=start
class Solution {
    public boolean lemonadeChange(int[] bills) {
        int f = 0, t = 0;
        for (int b : bills) {
            if (b == 5) {
                ++f;
            } else if (b == 10) {
                if (f == 0) {
                    return false;
                }
                --f;
                ++t;
            } else {
                if (t > 0 && f > 0) {
                    --t;
                    --f;
                } else if (f > 2) {
                    f -= 3;
                } else {
                    return false;
                }
            }
        }
        return true;
    }
}
// @lc code=end

