/*
 * @lc app=leetcode id=991 lang=csharp
 *
 * [991] Broken Calculator
 */

// @lc code=start
public class Solution {
    public int BrokenCalc(int X, int Y) {
        if (X >= Y) {
            return X - Y;
        }
        return 1 + BrokenCalc(X, Y % 2 == 0 ? Y / 2 : (Y + 1));
    }
}
// @lc code=end

