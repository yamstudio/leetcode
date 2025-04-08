/*
 * @lc app=leetcode id=1560 lang=java
 *
 * [1560] Most Visited Sector in  a Circular Track
 */

import java.util.ArrayList;
import java.util.List;

// @lc code=start
class Solution {
    public List<Integer> mostVisited(int n, int[] rounds) {
        int start = rounds[0], end = rounds[rounds.length - 1];
        if (start <= end) {
            List<Integer> ret = new ArrayList<>(end - start + 1);
            while (start <= end) {
                ret.add(start);
                ++start;
            }
            return ret;
        } else {
            List<Integer> ret = new ArrayList<>(end + n - start + 1);
            for (int i = 1; i <= end; ++i) {
                ret.add(i);
            }
            for (int i = start; i <= n; ++i) {
                ret.add(i);
            }
            return ret;
        }
    }
}
// @lc code=end

