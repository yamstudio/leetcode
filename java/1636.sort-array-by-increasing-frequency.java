/*
 * @lc app=leetcode id=1636 lang=java
 *
 * [1636] Sort Array by Increasing Frequency
 */

// @lc code=start

import java.util.Arrays;

class Solution {
    public int[] frequencySort(int[] nums) {
        int[] count = new int[201];
        for (int x : nums) {
            ++count[x + 100];
        }
        return Arrays
            .stream(nums)
            .boxed()
            .sorted(java.util.Comparator.comparingInt((Integer x) -> count[x + 100]).thenComparingInt(x -> -x))
            .mapToInt(x -> x)
            .toArray();
    }
}
// @lc code=end

