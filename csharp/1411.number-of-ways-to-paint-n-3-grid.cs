/*
 * @lc app=leetcode id=1411 lang=csharp
 *
 * [1411] Number of Ways to Paint N × 3 Grid
 */

// @lc code=start
public class Solution {
    public int NumOfWays(int n) {
        long two = 6, three = 6;
        while (--n > 0) {
            long ntwo = 3 * two + 2 * three, nthree = 2 * (two + three);
            two = ntwo % 1000000007;
            three = nthree % 1000000007;
        }
        return (int)((two + three) % 1000000007);
    }
}
// @lc code=end

