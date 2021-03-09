/*
 * @lc app=leetcode id=908 lang=java
 *
 * [908] Smallest Range I
 */

// @lc code=start
class Solution {
    public int smallestRangeI(int[] A, int K) {
        int min = Integer.MAX_VALUE, max = Integer.MIN_VALUE;
        for (int x : A) {
            min = Math.min(min, x);
            max = Math.max(max, x);
        }
        return Math.max(0, max - min - 2 * K);
    }
}
// @lc code=end

