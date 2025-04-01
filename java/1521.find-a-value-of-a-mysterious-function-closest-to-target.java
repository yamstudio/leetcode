/*
 * @lc app=leetcode id=1521 lang=java
 *
 * [1521] Find a Value of a Mysterious Function Closest to Target
 */

import java.util.HashSet;
import java.util.Set;

// @lc code=start

class Solution {
    public int closestToTarget(int[] arr, int target) {
        Set<Integer> all = new HashSet<>(), next = new HashSet<>();
        all.add(~0);
        int ret = Integer.MAX_VALUE;
        for (int x : arr) {
            for (int p : all) {
                ret = Math.min(Math.abs((p & x) - target), ret);
                next.add(p & x);
            }
            next.add(~0);
            all.clear();
            var tmp = all;
            all = next;
            next = tmp;

        }
        return ret;
    }
}
// @lc code=end

