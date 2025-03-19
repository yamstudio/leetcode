/*
 * @lc app=leetcode id=1477 lang=java
 *
 * [1477] Find Two Non-overlapping Sub-arrays Each With Target Sum
 */

import java.util.HashMap;
import java.util.Map;

// @lc code=start

class Solution {
    public int minSumOfLengths(int[] arr, int target) {
        int n = arr.length, acc = 0, minSize = n + 1, ret = n + 1;
        Map<Integer, Integer> valToIndex = new HashMap<>(n + 1);
        valToIndex.put(0, -1);
        for (int i = 0; i < n; ++i) {
            acc += arr[i];
            valToIndex.put(acc, i);
        }
        acc = 0;
        for (int i = 0; i < n; ++i) {
            acc += arr[i];
            Integer pi = valToIndex.get(acc - target);
            if (pi != null) {
                minSize = Math.min(minSize, i - pi);
            }
            if (minSize < n) {
                Integer ni = valToIndex.get(acc + target);
                if (ni != null) {
                    ret = Math.min(ret, minSize + ni - i);
                }
            }
        }
        return ret <= n ? ret : -1;
    }
}
// @lc code=end

