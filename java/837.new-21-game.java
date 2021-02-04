/*
 * @lc app=leetcode id=837 lang=java
 *
 * [837] New 21 Game
 */

// @lc code=start
class Solution {
    public double new21Game(int N, int K, int W) {
        if (N >= K + W || K == 0) {
            return 1.0;
        }
        double prevSum = 1.0, ret = 0.0;
        double[] p = new double[N + 1];
        p[0] = 1.0;
        for (int i = 1; i <= N; ++i) {
            p[i] = prevSum / W;
            if (i < K) {
                prevSum += p[i];
            } else {
                ret += p[i];
            }
            if (i >= W) {
                prevSum -= p[i - W];
            }
        }
        return ret;
    }
}
// @lc code=end

