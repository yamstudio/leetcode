/*
 * @lc app=leetcode id=1385 lang=java
 *
 * [1385] Find the Distance Value Between Two Arrays
 */

import java.util.Arrays;

// @lc code=start

class Solution {
    public int findTheDistanceValue(int[] arr1, int[] arr2, int d) {
        int ret = 0;
        Arrays.sort(arr2);
        for (int x : arr1) {
            if (good(arr2, x - d, x + d)) {
                ++ret;
            }
        }
        return ret;
    }

    private static boolean good(int[] arr, int min, int max) {
        int l = 0, r = arr.length - 1;
        while (l <= r) {
            int m = (l + r) / 2;
            if (arr[m] >= min && arr[m] <= max) {
                return false;
            } else if (arr[m] < min) {
                l = m + 1;
            } else {
                r = m - 1;
            }
        }
        return true;
    }
}
// @lc code=end

