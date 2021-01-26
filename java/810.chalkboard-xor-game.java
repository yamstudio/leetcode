/*
 * @lc app=leetcode id=810 lang=java
 *
 * [810] Chalkboard XOR Game
 */

// @lc code=start
class Solution {
    public boolean xorGame(int[] nums) {
        int x = 0;
        for (int y : nums) {
            x ^= y;
        }
        return nums.length % 2 == 0 || x == 0;
    }
}
// @lc code=end

