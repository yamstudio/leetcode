/*
 * @lc app=leetcode id=930 lang=java
 *
 * [930] Binary Subarrays With Sum
 */

import java.util.ArrayList;
import java.util.List;

// @lc code=start
class Solution {
    public int numSubarraysWithSum(int[] nums, int goal) {
        int n = nums.length;
        List<Integer> oneIndices = new ArrayList<>();
        oneIndices.add(-1);
        for (int i = 0; i < n; ++i) {
            if (nums[i] == 1) {
                oneIndices.add(i);
            }
        }
        oneIndices.add(n);
        int ret = 0;
        if (goal == 0) {
            for (int i = 1; i < oneIndices.size(); ++i) {
                int c = oneIndices.get(i) - oneIndices.get(i - 1);
                ret += c * (c - 1) / 2;
            }
        } else {
            for (int i = 1; i + goal < oneIndices.size(); ++i) {
                ret += (oneIndices.get(i) - oneIndices.get(i - 1)) * (oneIndices.get(i + goal) - oneIndices.get(i + goal - 1));
            }
        }
        return ret;
    }
}
// @lc code=end

