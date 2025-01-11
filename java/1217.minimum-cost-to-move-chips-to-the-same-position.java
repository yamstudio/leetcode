/*
 * @lc app=leetcode id=1217 lang=java
 *
 * [1217] Minimum Cost to Move Chips to The Same Position
 */

// @lc code=start
class Solution {
    public int minCostToMoveChips(int[] position) {
        int oddSum = 0, evenSum = 0;
        for (int p : position) {
            if (p % 2 == 1) {
                oddSum++;
            } else {
                evenSum++;
            }
        }
        return Math.min(oddSum, evenSum);
    }
}
// @lc code=end

