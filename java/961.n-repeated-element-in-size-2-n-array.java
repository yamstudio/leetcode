/*
 * @lc app=leetcode id=961 lang=java
 *
 * [961] N-Repeated Element in Size 2N Array
 */

import java.util.HashMap;
import java.util.Map;

// @lc code=start

class Solution {
    public int repeatedNTimes(int[] nums) {
        int n = nums.length / 2;
        var elementToCount = new HashMap<Integer, Integer>(n);
        for (int num : nums) {
            elementToCount.put(num, elementToCount.getOrDefault(num, 0) + 1);
        }
        return elementToCount
            .entrySet()
            .stream()
            .filter(entry -> entry.getValue() == n)
            .map(Map.Entry::getKey)
            .findAny()
            .orElseThrow();
    }
}
// @lc code=end

