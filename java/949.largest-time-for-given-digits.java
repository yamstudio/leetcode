/*
 * @lc app=leetcode id=949 lang=java
 *
 * [949] Largest Time for Given Digits
 */

// @lc code=start
class Solution {
    public String largestTimeFromDigits(int[] arr) {
        String ret = "";
        for (int i = 0; i < 4; ++i) {
            if (arr[i] > 2) {
                continue;
            }
            int d1 = arr[i];
            for (int j = 0; j < 4; ++j) {
                if (i == j) {
                    continue;
                }
                int d2 = arr[j];
                if (d1 == 2 && d2 > 3) {
                    continue;
                }
                for (int k = 0; k < 4; ++k) {
                    if (k == i || k == j) {
                        continue;
                    }
                    int d3 = arr[k];
                    if (d3 > 5) {
                        continue;
                    }
                    int d4 = arr[6 - i - j - k];
                    String curr = "%s%s:%s%s".formatted(d1, d2, d3, d4);
                    if (curr.compareTo(ret) > 0) {
                        ret = curr;
                    }
                }
            }
        }
        return ret;
    }
}
// @lc code=end

