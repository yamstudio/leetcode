/*
 * @lc app=leetcode id=1546 lang=java
 *
 * [1546] Maximum Number of Non-Overlapping Subarrays With Sum Equals Target
 */

import java.util.HashMap;
import java.util.Map;

// @lc code=start
class Solution {
    public int maxNonOverlapping(int[] nums, int target) {
        Map<Integer, Integer> sumToCount = new HashMap<>();
        int ret = 0, acc = 0;
        sumToCount.put(0, 0);
        for (int x : nums) {
            acc += x;
            Integer count = sumToCount.get(acc - target);
            if (count != null) {
                ret = Math.max(count + 1, ret);
            }
            sumToCount.put(acc, ret);
        }
        return ret;
    }
}
// @lc code=end

