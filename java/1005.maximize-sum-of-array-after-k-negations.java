/*
 * @lc app=leetcode id=1005 lang=java
 *
 * [1005] Maximize Sum Of Array After K Negations
 */

// @lc code=start
class Solution {
    public int largestSumAfterKNegations(int[] nums, int k) {
        int[] count = new int[201];
        for (int num : nums) {
            ++count[num + 100];
        }
        int ret = 0;
        for (int i = 0; i < 100; ++i) {
            if (count[i] == 0) {
                continue;
            }
            if (k > 0) {
                int d = Math.min(k, count[i]);
                count[i] -= d;
                count[200 - i] += d;
                k -= d;
            }
            if (k == 0) {
                ret += (i - 100) * count[i];
            }
        }
        k = k % 2;
        for (int i = 100; i <= 200; ++i) {
            if (count[i] == 0) {
                continue;
            }
            if (k == 1) {
                k = 0;
                ret = (i - 100) * (count[i] - 2);
            } else {
                ret += (i - 100) * count[i];
            }
        }
        return ret;
    }
}
// @lc code=end

