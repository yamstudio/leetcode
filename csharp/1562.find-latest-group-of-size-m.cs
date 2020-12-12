/*
 * @lc app=leetcode id=1562 lang=csharp
 *
 * [1562] Find Latest Group of Size M
 */

// @lc code=start
public class Solution {
    public int FindLatestStep(int[] arr, int m) {
        int acc = 0, ret = -1, n = arr.Length;
        int[,] all = new int[n + 2, 2];
        for (int i = 0; i < n; ++i) {
            int j = arr[i], lgl = all[j - 1, 0], rgr = all[j + 1, 1];
            if (lgl == 0 && rgr == 0) {
                all[j, 0] = j;
                all[j, 1] = j;
                if (m == 1) {
                    ++acc;
                }
            } else if (lgl == 0) {
                all[rgr, 0] = j;
                all[j, 1] = rgr;
                if (rgr - j == m - 1) {
                    ++acc;
                } else if (rgr - j == m) {
                    --acc;
                }
            } else if (rgr == 0) {
                all[lgl, 1] = j;
                all[j, 0] = lgl;
                if (j - lgl == m - 1) {
                    ++acc;
                } else if (j - lgl == m) {
                    --acc;
                }
            } else {
                all[lgl, 1] = rgr;
                all[rgr, 0] = lgl;
                if (j - lgl == m) {
                    --acc;
                }
                if (rgr - j == m) {
                    --acc;
                }
                if (rgr - lgl == m - 1) {
                    ++acc;
                }
            }
            if (acc > 0) {
                ret = i + 1;
            }
        }
        return ret;
    }
}
// @lc code=end

