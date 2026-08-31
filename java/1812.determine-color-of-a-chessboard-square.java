/*
 * @lc app=leetcode id=1812 lang=java
 *
 * [1812] Determine Color of a Chessboard Square
 */

// @lc code=start
class Solution {
    public boolean squareIsWhite(String coordinates) {
        return (coordinates.charAt(0) % 2) != (coordinates.charAt(1) % 2);
    }
}
// @lc code=end

