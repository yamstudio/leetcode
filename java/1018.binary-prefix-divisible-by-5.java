/*
 * @lc app=leetcode id=1018 lang=java
 *
 * [1018] Binary Prefix Divisible By 5
 */

import java.util.ArrayList;
import java.util.List;

// @lc code=start

class Solution {
    public List<Boolean> prefixesDivBy5(int[] nums) {
        List<Boolean> ret = new ArrayList<>();
        int n = 0;
        for (int num : nums) {
            n = ((n << 1) | num) % 5;
            ret.add(n == 0);
        }
        return ret;
    }
}
// @lc code=end

