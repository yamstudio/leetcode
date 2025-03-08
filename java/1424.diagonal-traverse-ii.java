/*
 * @lc app=leetcode id=1424 lang=java
 *
 * [1424] Diagonal Traverse II
 */

import java.util.ArrayList;
import java.util.List;

// @lc code=start
class Solution {
    public int[] findDiagonalOrder(List<List<Integer>> nums) {
        int k = nums.size(), n = 0;
        List<List<Integer>> lists = new ArrayList<>();
        for (int i = 0; i < k; ++i) {
            List<Integer> row = nums.get(i);
            int s = row.size(), len = s + i;
            for (int l = lists.size(); l < len; ++l) {
                lists.add(new ArrayList<>());
            }
            for (int j = 0; j < s; ++j) {
                lists.get(j + i).add(row.get(j));
            }
            n += s;
        }
        int[] ret = new int[n];
        int j = 0;
        for (var list : lists) {
            for (int i = list.size() - 1; i >= 0; --i) {
                ret[j++] = list.get(i);
            }
        }
        return ret;
    }
}
// @lc code=end

