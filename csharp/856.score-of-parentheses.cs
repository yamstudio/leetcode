/*
 * @lc app=leetcode id=856 lang=csharp
 *
 * [856] Score of Parentheses
 */

// @lc code=start
public class Solution {

    private static int ScoreOfParenthesesResurce(string S, ref int index) {
        int n = S.Length, ret = 0;
        while (index < n && S[index] != ')') {
            if (S[++index] == ')') {
                ++ret;
            } else {
                ret += 2 * ScoreOfParenthesesResurce(S, ref index);
            }
            ++index;
        }
        return ret;
    }

    public int ScoreOfParentheses(string S) {
        int index = 0;
        return ScoreOfParenthesesResurce(S, ref index);
    }
}
// @lc code=end

