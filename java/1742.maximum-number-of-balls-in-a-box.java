/*
 * @lc app=leetcode id=1742 lang=java
 *
 * [1742] Maximum Number of Balls in a Box
 */

import java.util.Map;
import java.util.HashMap;

// @lc code=start
class Solution {
    public int countBalls(int lowLimit, int highLimit) {
        int ret = 0;
        Map<Integer, Integer> count = new HashMap<>();
        for (int i = lowLimit; i <= highLimit; ++i) {
            int acc = 0, x = i;
            while (x > 0) {
                acc += x % 10;
                x /= 10;
            }
            int c = count.getOrDefault(acc, 0) + 1;
            count.put(acc, c);
            ret = Math.max(c, ret);
        }
        return ret;
    }
}
// @lc code=end

