/*
 * @lc app=leetcode id=1431 lang=java
 *
 * [1431] Kids With the Greatest Number of Candies
 */

import java.util.ArrayList;
import java.util.List;

// @lc code=start
class Solution {
    public List<Boolean> kidsWithCandies(int[] candies, int extraCandies) {
        int n = candies.length, max = 0;
        for (int c : candies) {
            max = Math.max(c, max);
        }
        List<Boolean> ret = new ArrayList<>(n);
        for (int i = 0; i < n; ++i) {
            ret.add(candies[i] + extraCandies >= max);
        }
        return ret;
    }
}
// @lc code=end

