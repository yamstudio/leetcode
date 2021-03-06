/*
 * @lc app=leetcode id=904 lang=java
 *
 * [904] Fruit Into Baskets
 */

// @lc code=start
class Solution {
    public int totalFruit(int[] tree) {
        int ret = 0, acc = 0, count = 0, f = -1, s = -1;
        for (int x : tree) {
            if (x == s) {
                ++acc;
                ++count;
            } else {
                if (x == f) {
                    ++acc;
                } else {
                    acc = 1 + count;
                }
                f = s;
                s = x;
                count = 1;
            }
            ret = Math.max(ret, acc);
        }
        return ret;
    }
}
// @lc code=end

