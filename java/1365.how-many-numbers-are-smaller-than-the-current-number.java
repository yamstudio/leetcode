/*
 * @lc app=leetcode id=1365 lang=java
 *
 * [1365] How Many Numbers Are Smaller Than the Current Number
 */

import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

// @lc code=start
class Solution {
    public int[] smallerNumbersThanCurrent(int[] nums) {
        int n = nums.length;
        Map<Integer, Set<Integer>> numToIndices = new HashMap<>();
        for (int i = 0; i < n; ++i) {
            numToIndices.computeIfAbsent(nums[i], ignored -> new HashSet<>()).add(i);
        }
        int acc = 0;
        int[] ret = new int[n];
        for (int i = 0; i <= 100; ++i) {
            Set<Integer> indices = numToIndices.get(i);
            if (indices == null) {
                continue;
            }
            for (int x : indices) {
                ret[x] = acc;
            }
            acc += indices.size();
        }
        return ret;
    }
}
// @lc code=end

