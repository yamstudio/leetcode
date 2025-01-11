/*
 * @lc app=leetcode id=1223 lang=java
 *
 * [1223] Dice Roll Simulation
 */

// @lc code=start
class Solution {
    public int dieSimulator(int n, int[] rollMax) {
        int k = 1 + Math.max(
            rollMax[0], 
            Math.max(
                rollMax[1], 
                Math.max(
                    rollMax[2],
                    Math.max(
                        rollMax[3],
                        Math.max(
                            rollMax[4],
                            rollMax[5])
                    )
                )));
        long[][] count = new long[k][7];
        count[0][0] = 1;
        count[0][1] = 1;
        count[0][2] = 1;
        count[0][3] = 1;
        count[0][4] = 1;
        count[0][5] = 1;
        count[0][6] = 6;
        for (int l = 1; l < n; ++l) {
            int i = l % k;
            long sum = 0, prevSum = count[(i - 1 + k) % k][6];
            for (int j = 0; j < 6; ++j) {
                if (l < rollMax[j]) {
                    count[i][j] = prevSum;
                } else if (l == rollMax[j]) {
                    count[i][j] = prevSum - 1;
                } else {
                    int ri = (i - rollMax[j] - 1 + k) % k; 
                    count[i][j] = (
                        1000000007
                        + prevSum 
                        - (
                            1000000007 + count[ri][6] - count[ri][j]
                        ) % 1000000007
                    ) % 1000000007;
                }
                sum = (sum + count[i][j]) % 1000000007;
            }
            count[i][6] = sum;
        }
        return (int)count[(n - 1) % k][6];
    }
}
// @lc code=end

