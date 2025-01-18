/*
 * @lc app=leetcode id=1248 lang=java
 *
 * [1248] Count Number of Nice Subarrays
 */

import java.util.ArrayDeque;

// @lc code=start
class Solution {
    public int numberOfSubarrays(int[] nums, int k) {
        var odds = new ArrayDeque<Integer>(k + 2);
        odds.addFirst(-1);
        int n = nums.length, ret = 0;
        for (int i = 0; i < n; ++i) {
            int num = nums[i];
            if (num % 2 == 1) {
                odds.add(i);
            }
            if (odds.size() == k + 2) {
                odds.removeFirst();
            }
            if (odds.size() == k + 1) {
                var it = odds.iterator();
                int f = it.next();
                ret += it.next() - f;
            }
        }
        return ret;
    }
}
// @lc code=end

