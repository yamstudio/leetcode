/*
 * @lc app=leetcode id=927 lang=java
 *
 * [927] Three Equal Parts
 */

// @lc code=start
class Solution {
    public int[] threeEqualParts(int[] arr) {
        int n = arr.length, p1 = -1, p2, p3, acc = 0, count = 0;
        for (int i = 0; i < n; ++i) {
            if (arr[i] == 1) {
                ++count;
            }
        }
        if (count == 0) {
            return new int[] { 0, n - 1 };
        }
        if (count % 3 != 0) {
            return new int[] { -1, -1 };
        }
        count /= 3;
        while (acc == 0) {
            ++p1;
            if (arr[p1] == 1) {
                ++acc;
            }
        }
        p2 = p1;
        while (acc <= count) {
            ++p2;
            if (arr[p2] == 1) {
                ++acc;
            }
        }
        p3 = p2;
        while (acc <= 2 * count) {
            ++p3;
            if (arr[p3] == 1) {
                ++acc;
            }
        }
        while (p3 < n) {
            int v = arr[p3++];
            if (v != arr[p1++] || v != arr[p2++]) {
                return new int[] { -1, -1 };
            }
        }
        return new int[] { p1 - 1, p2 };
    }
}
// @lc code=end

