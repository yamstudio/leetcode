/*
 * @lc app=leetcode id=1678 lang=csharp
 *
 * [1678] Goal Parser Interpretation
 */

// @lc code=start
public class Solution {
    public string Interpret(string command) {
        return command.Replace("(al)", "al").Replace("()", "o");
    }
}
// @lc code=end

