/*
 * @lc app=leetcode id=1238 lang=java
 *
 * [1238] Circular Permutation in Binary Representation
 */

import java.util.ArrayList;
import java.util.List;

// @lc code=start
class Solution {
    public List<Integer> circularPermutation(int n, int start) {
        int t = (1 << n) - 1;
        List<Integer> ret = new ArrayList<>(t + 1);
        for (int i = 0; i <= t; ++i) {
            ret.add(start ^ i ^ (i >> 1));
        }
        return ret;
    }
}
// @lc code=end

