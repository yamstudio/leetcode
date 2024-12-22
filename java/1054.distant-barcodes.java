/*
 * @lc app=leetcode id=1054 lang=java
 *
 * [1054] Distant Barcodes
 */

// @lc code=start
class Solution {
    public int[] rearrangeBarcodes(int[] barcodes) {
        int n = barcodes.length, mi = 0, m = 0;
        int[] count = new int[10001];
        for (int b : barcodes) {
            ++count[b];
            if (count[b] > m) {
                m = count[b];
                mi = b;
            }
        }
        int[] ret = new int[n];
        int i = 0;
        while (m-- > 0) {
            ret[i] = mi;
            i += 2;
        }
        count[mi] = 0;
        for (int b = 1; b <= 10000; ++b) {
            for (int j = 0; j < count[b]; ++j) {
                if (i >= n) {
                    i = 1;
                }
                ret[i] = b;
                i += 2;
            }
        }
        return ret;
    }
}
// @lc code=end

