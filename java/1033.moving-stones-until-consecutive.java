/*
 * @lc app=leetcode id=1033 lang=java
 *
 * [1033] Moving Stones Until Consecutive
 */

// @lc code=start
class Solution {
    public int[] numMovesStones(int a, int b, int c) {
        int max = Math.max(a, Math.max(b, c)), min = Math.min(a, Math.min(b, c)), mid = a + b + c - min - max, minGap = Math.min(mid - min, max - mid), maxGap = Math.max(mid - min, max - mid);
        return new int[] { maxGap == 1 ? 0 : (minGap < 3 ? 1 : 2), max - min - 2};
    }
}
// @lc code=end

