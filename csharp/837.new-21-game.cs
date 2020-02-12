/*
 * @lc app=leetcode id=837 lang=csharp
 *
 * [837] New 21 Game
 */

using System;

// @lc code=start
public class Solution {
    public double New21Game(int N, int K, int W) {
        int m = K + W;
        if (N >= m || K == 0) {
            return 1.0;
        }
        double[] s = new double[m];
        s[0] = 1.0;
        for (int i = 1; i < m; ++i) {
            double v = s[Math.Min(i, K) - 1], p;
            if (i <= W) {
                p = v / W;
            } else {
                p = (v - s[i - W - 1]) / W;
            }
            s[i] = s[i - 1] + p;
        }
        return (s[N] - s[K - 1]) / (s[m - 1] - s[K - 1]);
    }
}
// @lc code=end

