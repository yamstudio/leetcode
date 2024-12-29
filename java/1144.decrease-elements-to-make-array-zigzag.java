/*
 * @lc app=leetcode id=1144 lang=java
 *
 * [1144] Decrease Elements To Make Array Zigzag
 */

// @lc code=start
class Solution {
    public int movesToMakeZigzag(int[] nums) {
        int incVal = Integer.MAX_VALUE, incMoves = 0, decVal = Integer.MIN_VALUE, decMoves = 0;
        for (int num : nums) {
            int nextDecVal, nextDecMoves, nextIncVal, nextIncMoves;
            if (num < incVal) {
                nextDecVal = num;
                nextDecMoves = incMoves;
            } else {
                nextDecVal = incVal - 1;
                nextDecMoves = num - incVal + 1 + incMoves;
            }
            if (num > decVal) {
                nextIncVal = num;
                nextIncMoves = decMoves;
            } else {
                nextIncVal = num;
                nextIncMoves = decVal - num + 1 + decMoves;
            }
            decVal = nextDecVal;
            decMoves = nextDecMoves;
            incVal = nextIncVal;
            incMoves = nextIncMoves;
        }
        return Math.min(incMoves, decMoves);
    }
}
// @lc code=end

