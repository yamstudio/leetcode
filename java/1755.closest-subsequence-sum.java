/*
 * @lc app=leetcode id=1755 lang=java
 *
 * [1755] Closest Subsequence Sum
 */

import java.util.HashSet;
import java.util.Set;
import java.util.TreeSet;

// @lc code=start

class Solution {
    public int minAbsDifference(int[] nums, int goal) {
        Set<Integer> left = new HashSet<>(), right = new HashSet<>();
        int n = nums.length, ret = Math.abs(goal);
        fill(nums, 0, n / 2, 0, left);
        fill(nums, n / 2, n, 0, right);
        TreeSet<Integer> sortedRight = new TreeSet<>(right);
        for (int l : left) {
            int r = goal - l;
            if (right.contains(r)) {
                return 0;
            }
            Integer low = sortedRight.lower(r);
            if (low != null) {
                ret = Math.min(ret, Math.abs(l + low - goal));
            }
            Integer high = sortedRight.higher(r);
            if (high != null) {
                ret = Math.min(ret, Math.abs(l + high - goal));
            }
        }
        return ret;
    }

    private static void fill(int[] nums, int curr, int end, int sum, Set<Integer> sums) {
        if (curr == end) {
            sums.add(sum);
            return;
        }
        fill(nums, curr + 1, end, sum, sums);
        fill(nums, curr + 1, end, sum + nums[curr], sums);
    }
}
// @lc code=end

