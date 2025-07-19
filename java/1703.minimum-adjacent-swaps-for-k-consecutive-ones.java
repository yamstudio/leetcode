/*
 * @lc app=leetcode id=1703 lang=java
 *
 * [1703] Minimum Adjacent Swaps for K Consecutive Ones
 */

import java.util.ArrayList;
import java.util.List;

// @lc code=start

class Solution {
    public int minMoves(int[] nums, int k) {
        List<Integer> oneIndices = new ArrayList<>();
        int n = nums.length;
        for (int i = 0; i < n; ++i) {
            if (nums[i] == 1) {
                oneIndices.add(i);
            }
        }
        int l = oneIndices.size();
        int[] sums = new int[l + 1];
        for (int i = 0; i < l; ++i) {
            sums[i + 1] = sums[i] + oneIndices.get(i);
        }
        int ret = Integer.MAX_VALUE;
        for (int i = 0; i + k <= l; ++i) {
            ret = Math.min(ret, sums[i + k] - sums[i + k / 2] - (sums[i + (k + 1) / 2] - sums[i]) - ((k + 1) / 2) * (k / 2));
        }
        return ret;
    }
}
// @lc code=end

