/*
 * @lc app=leetcode id=1550 lang=java
 *
 * [1550] Three Consecutive Odds
 */

// @lc code=start
class Solution {
    public boolean threeConsecutiveOdds(int[] arr) {
        int acc = 0;
        for (int x : arr) {
            if (x % 2 == 1) {
                if (++acc == 3) {
                    return true;
                }
            } else {
                acc = 0;
            }
        }
        return false;
    }
}
// @lc code=end

