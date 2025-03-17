/*
 * @lc app=leetcode id=1467 lang=java
 *
 * [1467] Probability of a Two Boxes Having The Same Number of Distinct Balls
 */

// @lc code=start
class Solution {
    private static final int[] FACTORIALS = new int[] {
        1, 1, 2, 6, 24, 120, 720
    };

    public double getProbability(int[] balls) {
        Pair p = getProbability(balls, 0, 0, 0, 0, 0);
        return p.good() / p.total();
    }

    private Pair getProbability(int[] balls, int i, int c1, int c2, int d1, int d2) {
        if (i == balls.length) {
            if (c1 != c2) {
                return new Pair(0, 0);
            }
            if (d1 == d2) {
                return new Pair(1, 1);
            }
            return new Pair(0, 1);
        }
        int curr = balls[i];
        double good, total;
        Pair all1 = getProbability(balls, i + 1, c1 + curr, c2, d1 + 1, d2);
        good = all1.good() / FACTORIALS[curr];
        total = all1.total() / FACTORIALS[curr];
        Pair all2 = getProbability(balls, i + 1, c1, c2 + curr, d1, d2 + 1);
        good += all2.good() / FACTORIALS[curr];
        total += all2.total() / FACTORIALS[curr];
        for (int l1 = 1; l1 < curr; ++l1) {
            double div = FACTORIALS[l1] * FACTORIALS[curr - l1];
            Pair p = getProbability(balls, i + 1, c1 + l1, c2 - l1 + curr, d1 + 1, d2 + 1);
            good += p.good() / div;
            total += p.total() / div;
        }
        return new Pair(good, total);
    }

    private record Pair(double good, double total) {}
}
// @lc code=end

