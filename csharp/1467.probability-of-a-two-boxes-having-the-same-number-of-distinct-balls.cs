/*
 * @lc app=leetcode id=1467 lang=csharp
 *
 * [1467] Probability of a Two Boxes Having The Same Number of Distinct Balls
 */

// @lc code=start
public class Solution {

    private static int[] Factorials = new int[] {
        1, 1, 2, 6, 24, 120, 720
    };


    private static (double Total, double Valid) GetProbability(int[] balls, int i, int count1, int count2, int distinct1, int distinct2) {
        if (i == balls.Length) {
            if (count1 != count2) {
                return (Total: 0, Valid: 0);
            }
            return (Total: 1, Valid: distinct1 == distinct2 ? 1 : 0);
        }
        double total = 0, valid = 0;
        var all1 = GetProbability(balls, i + 1, count1 + balls[i], count2, distinct1 + 1, distinct2);
        total += all1.Total / Factorials[balls[i]];
        valid += all1.Valid / Factorials[balls[i]];
        var all2 = GetProbability(balls, i + 1, count1, count2 + balls[i], distinct1, distinct2 + 1);
        total += all2.Total / Factorials[balls[i]];
        valid += all2.Valid / Factorials[balls[i]];
        for (int j = 1; j < balls[i]; ++j) {
            var curr = GetProbability(balls, i + 1, count1 + j, count2 + balls[i] - j, distinct1 + 1, distinct2 + 1);
            total += curr.Total / (Factorials[j] * Factorials[balls[i] - j]);
            valid += curr.Valid / (Factorials[j] * Factorials[balls[i] - j]);
        }
        return (Total: total, Valid: valid);
    }

    public double GetProbability(int[] balls) {
        var ret = GetProbability(balls, 0, 0, 0, 0, 0);
        return ret.Valid / ret.Total;
    }
}
// @lc code=end

