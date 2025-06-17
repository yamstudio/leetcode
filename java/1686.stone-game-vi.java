/*
 * @lc app=leetcode id=1686 lang=java
 *
 * [1686] Stone Game VI
 */

import java.util.Arrays;

// @lc code=start

class Solution {
    public int stoneGameVI(int[] aliceValues, int[] bobValues) {
        int n = aliceValues.length;
        Pair[] pairs = new Pair[n];
        for (int i = 0; i < n; ++i) {
            pairs[i] = new Pair(aliceValues[i], bobValues[i]);
        }
        Arrays.sort(pairs, java.util.Comparator.comparingInt((Pair p) -> p.a() + p.b()).reversed());
        int acc = 0;
        for (int i = 0; i < n; ++i) {
            if (i % 2 == 0) {
                acc += pairs[i].a();
            } else {
                acc -= pairs[i].b();
            }
        }
        return acc == 0 ? 0 : acc > 0 ? 1 : -1;
    }

    private record Pair(int a, int b) {}
}
// @lc code=end

