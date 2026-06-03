/*
 * @lc app=leetcode id=1760 lang=java
 *
 * [1760] Minimum Limit of Balls in a Bag
 */

// @lc code=start
class Solution {
    public int minimumSize(int[] nums, int maxOperations) {
        int l = 1, r = 1_000_000_000;
        while (l < r) {
            int m = (l + r) / 2, acc = 0;
            for (int x : nums) {
                acc += (x - 1) / m;
            }
            if (acc > maxOperations) {
                l = m + 1;
            } else {
                r = m;
            }
        }
        return l;
    }
}
// @lc code=end

