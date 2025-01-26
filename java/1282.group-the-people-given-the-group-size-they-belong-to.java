/*
 * @lc app=leetcode id=1282 lang=java
 *
 * [1282] Group the People Given the Group Size They Belong To
 */

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

// @lc code=start
class Solution {
    public List<List<Integer>> groupThePeople(int[] groupSizes) {
        List<List<Integer>> ret = new ArrayList<>();
        Map<Integer, List<Integer>> map = new HashMap<>();
        int n = groupSizes.length;
        for (int i = 0; i < n; ++i) {
            int c = groupSizes[i];
            List<Integer> curr = map.computeIfAbsent(c, ignored -> new ArrayList<>(c));
            if (curr.size() == c) {
                curr = new ArrayList<>(c);
                map.put(c, curr);
            }
            if (curr.size() == 0) {
                ret.add(curr);
            }
            curr.add(i);
        }
        return ret;
    }
}
// @lc code=end

