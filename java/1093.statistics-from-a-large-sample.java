/*
 * @lc app=leetcode id=1093 lang=java
 *
 * [1093] Statistics from a Large Sample
 */

// @lc code=start
class Solution {
    public double[] sampleStats(int[] count) {
        double min = 256, max = -1, sum = 0;
        int mode = 0, n = 0;
        for (int i = 0; i < 256; ++i) {
            if (count[i] == 0) {
                continue;
            }
            n += count[i];
            min = Math.min(min, (double)i);
            max = Math.max(max, (double)i);
            sum += (double)i * (double)count[i];
            if (count[i] > count[mode]) {
                mode = i;
            }
        }
        double median = -1;
        int acc = 0;
        for (int i = 0; i < 256; ++i) {
            if (count[i] == 0) {
                continue;
            }
            acc += count[i];
            if (acc > n / 2) {
                median = i;
                break;
            }
            if (n % 2 == 0 && acc == n / 2) {
                int j;
                for (j = i + 1; count[j] == 0; ++j);
                median = ((double)i + (double)j) / 2.0;
                break;
            }
        }
        return new double[] {
            min,
            max,
            sum / (double)n,
            median,
            mode
        };
    }
}
// @lc code=end

