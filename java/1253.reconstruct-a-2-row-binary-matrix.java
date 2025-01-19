/*
 * @lc app=leetcode id=1253 lang=java
 *
 * [1253] Reconstruct a 2-Row Binary Matrix
 */

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

// @lc code=start
class Solution {
    public List<List<Integer>> reconstructMatrix(int upper, int lower, int[] colsum) {
        int n = colsum.length;
        List<Integer> upperList = new ArrayList<>(n), lowerList = new ArrayList<>(n);
        for (int i = 0; i < n; ++i) {
            int s = colsum[i];
            if (s != 2) {
                upperList.add(0);
                lowerList.add(0);
                continue;
            }
            upperList.add(1);
            lowerList.add(1);
            --upper;
            --lower;
        }
        for (int i = 0; i < n; ++i) {
            int s = colsum[i];
            if (s != 1) {
                continue;
            }
            if (upper > 0) {
                upperList.set(i, 1);
                --upper;
            } else {
                lowerList.set(i, 1);
                --lower;
            }
        }
        if (upper != 0 || lower != 0) {
            return Collections.emptyList();
        }
        return List.of(upperList, lowerList);
    }
}
// @lc code=end

