/*
 * @lc app=leetcode id=1711 lang=java
 *
 * [1711] Count Good Meals
 */

import java.util.HashMap;
import java.util.Map;

// @lc code=start

class Solution {

    private static int MAX = 1 << 21;

    public int countPairs(int[] deliciousness) {
        Map<Integer, Integer> count = new HashMap<>();
        for (int d : deliciousness) {
            count.put(d, count.getOrDefault(d, 0) + 1);
        }
        long ret = 0;
        for (var p : count.entrySet()) {
            int v = p.getKey(), c = p.getValue();
            for (int s = 1; s <= MAX; s <<= 1) {
                int d = s - v;
                if (d < v) {
                    continue;
                }
                if (d == v) {
                    ret = (ret + (long)c * (long)(c - 1) / 2) % 1000000007;
                } else {
                    ret = (ret + (long)c * (long)count.getOrDefault(d, 0)) % 1000000007;
                }
            }
        }
        return (int)ret;
    }
}
// @lc code=end

