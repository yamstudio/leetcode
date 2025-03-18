/*
 * @lc app=leetcode id=1471 lang=java
 *
 * [1471] The k Strongest Values in an Array
 */

import java.util.Arrays;

// @lc code=start

class Solution {
    public int[] getStrongest(int[] arr, int k) {
        Arrays.sort(arr);
        int n = arr.length, mid = arr[(n - 1) / 2], l = 0, r = n - 1;
        int[] ret = new int[k];
        for (int i = 0; i < k; ++i) {
            int lv = mid - arr[l], rv = arr[r] - mid;
            if (lv > rv) {
                ret[i] = arr[l++];
            } else {
                ret[i] = arr[r--];
            }
        }
        return ret;
    }
}
// @lc code=end

