/*
 * @lc app=leetcode id=657 lang=csharp
 *
 * [657] Robot Return to Origin
 */

// @lc code=start
public class Solution {
    public bool JudgeCircle(string moves) {
        if (moves.Length % 2 != 0) {
            return false;
        }
        int x = 0, y = 0;
        foreach (char c in moves) {
            switch (c) {
                case 'U':
                    ++y;
                    break;
                case 'D':
                    --y;
                    break;
                case 'L':
                    --x;
                    break;
                default:
                    ++x;
                    break;
            }
        }
        return x == 0 && y == 0;
    }
}
// @lc code=end

