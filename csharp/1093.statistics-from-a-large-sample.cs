/*
 * @lc app=leetcode id=1093 lang=csharp
 *
 * [1093] Statistics from a Large Sample
 */

// @lc code=start
public class Solution {
    public double[] SampleStats(int[] count) {
        int n = 0, mc = 0, acc = 0;
        double min = -1.0, max = -1.0, sum = 0.0, mode = -1.0, median = 0.0;
        for (int i = 0; i < 256; ++i) {
            int c = count[i];
            if (c == 0) {
                continue;
            }
            n += c;
            sum += (double)i * (double)c;
            if (mc < c) {
                mc = c;
                mode = (double)i;
            }
            if (min == -1.0) {
                min = (double)i;
            }
            max = (double)i;
        }
        for (int i = 0; i < 256; ++i) {
            int nacc = acc + count[i];
            if (nacc > n / 2) {
                median = (float)i;
                break;
            } else if (nacc == n / 2 && n % 2 == 0) {
                for (int j = i + 1; j < 256; ++j) {
                    if (count[j] > 0) {
                        median = (float)(i + j) / 2.0;
                    }
                }
                break;
            }
            acc = nacc;
        }
        return new double[] { min, max, sum / (double)n, median, mode };
    }
}
// @lc code=end