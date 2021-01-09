/*
 * @lc app=leetcode id=1686 lang=csharp
 *
 * [1686] Stone Game VI
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int StoneGameVI(int[] aliceValues, int[] bobValues) {
        int score = 0;
        bool alice = true;
        foreach (var stone in aliceValues
            .Zip(bobValues, (a, b) => (Alice: a, Bob: b))
            .OrderByDescending(s => s.Bob + s.Alice)) {
            if (alice) {
                score += stone.Alice;
            } else {
                score -= stone.Bob;
            }
            alice = !alice;
        }
        return score == 0 ? 0 : (score > 0 ? 1 : -1);
    }
}
// @lc code=end

