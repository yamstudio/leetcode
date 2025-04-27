/*
 * @lc app=leetcode id=1629 lang=java
 *
 * [1629] Slowest Key
 */

import java.util.Arrays;

// @lc code=start

class Solution {
    public char slowestKey(int[] releaseTimes, String keysPressed) {
        int n = releaseTimes.length;
        Pair[] pairs = new Pair[n];
        for (int i = 0; i < n; ++i) {
            pairs[i] = new Pair(keysPressed.charAt(i), releaseTimes[i]);
        }
        Arrays.sort(pairs, java.util.Comparator.comparingInt(Pair::t));
        char ret = pairs[0].c();
        int mt = pairs[0].t();
        for (int i = 1; i < n; ++i) {
            char c = pairs[i].c();
            int t = pairs[i].t() - pairs[i - 1].t();
            if (t > mt || (t == mt && c > ret)) {
                mt = t;
                ret = c;
            }
        }
        return ret;
    }

    private record Pair(char c, int t) {}
}
// @lc code=end

