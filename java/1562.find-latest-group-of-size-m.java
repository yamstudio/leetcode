/*
 * @lc app=leetcode id=1562 lang=java
 *
 * [1562] Find Latest Group of Size M
 */

// @lc code=start
class Solution {
    public int findLatestStep(int[] arr, int m) {
        int ret = -1, count = 0, n = arr.length;
        int[] left = new int[n + 2], right = new int[n + 2];
        for (int i = 0; i < n; ++i) {
            int x = arr[i];
            if (left[x - 1] == 0 && right[x + 1] == 0) {
                left[x] = x;
                right[x] = x;
                if (m == 1) {
                    ++count;
                }
            } else if (left[x - 1] == 0) {
                right[x] = right[x + 1];
                left[right[x]] = x;
                if (right[x] - x + 1 == m) {
                    ++count;
                } else if (right[x] - x == m) {
                    --count;
                }
            } else if (right[x + 1] == 0) {
                left[x] = left[x - 1];
                right[left[x]] = x;
                if (x - left[x] + 1 == m) {
                    ++count;
                } else if (x - left[x] == m) {
                    --count;
                }
            } else {
                if (x - left[x - 1] == m) {
                    --count;
                }
                if (right[x + 1] - x == m) {
                    --count;
                }
                right[left[x - 1]] = right[x + 1];
                left[right[x + 1]] = left[x - 1];
                if (right[x + 1] - left[x - 1] + 1 == m) {
                    ++count;
                }
            }
            if (count > 0) {
                ret = i + 1;
            }
        }
        return ret;
    }
}
// @lc code=end

