/*
 * @lc app=leetcode id=1104 lang=java
 *
 * [1104] Path In Zigzag Labelled Binary Tree
 */

import java.util.Arrays;
import java.util.List;

// @lc code=start
class Solution {
    public List<Integer> pathInZigZagTree(int label) {
        int m, p, l = label;
        for (m = 1, p = 0; m * 2 <= label; ++p, m *= 2);
        int[] ret = new int[p + 1];
        for (; p >= 0; --p, m /= 2) {
            ret[p] = l;
            l = m - 1 - (l - m) / 2;
        }
        return Arrays.stream(ret).boxed().toList();
    }
}
// @lc code=end

