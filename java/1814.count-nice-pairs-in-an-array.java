/*
 * @lc app=leetcode id=1814 lang=java
 *
 * [1814] Count Nice Pairs in an Array
 */

import java.util.Map;
import java.util.HashMap;

// @lc code=start
class Solution {
    public int countNicePairs(int[] nums) {
        Map<Integer, Integer> count = new HashMap<>();
        int ret = 0;
        for (int x : nums) {
            int d = x - rev(x), c = count.getOrDefault(d, 0);
            count.put(d, c + 1);
            ret = (ret + c) % 1000000007;
        }
        return ret;
    }

    private static int rev(int x) {
        int r = 0;
        while (x > 0) {
            r = 10 * r + x % 10;
            x /= 10;
        }
        return r;
    }
}
// @lc code=end

