/*
 * @lc app=leetcode id=1200 lang=java
 *
 * [1200] Minimum Absolute Difference
 */

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

// @lc code=start
class Solution {
    public List<List<Integer>> minimumAbsDifference(int[] arr) {
        Arrays.sort(arr);
        int minDiff = Integer.MAX_VALUE, n = arr.length, c = 0;
        for (int i = 1; i < n; ++i) {
            int diff = arr[i] - arr[i - 1];
            if (diff == minDiff) {
                ++c;
            } else if (diff < minDiff) {
                c = 1;
                minDiff = diff;
            }
        }
        List<List<Integer>> ret = new ArrayList<>(c);
        for (int i = 1; i < n; ++i) {
            int l = arr[i - 1], r = arr[i];
            if (r - l == minDiff) {
                ret.add(List.of(l, r));
            }
        }
        return ret;
    }
}
// @lc code=end

