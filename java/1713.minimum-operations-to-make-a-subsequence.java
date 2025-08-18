/*
 * @lc app=leetcode id=1713 lang=java
 *
 * [1713] Minimum Operations to Make a Subsequence
 */

import java.util.HashMap;
import java.util.Map;
import java.util.TreeSet;

// @lc code=start
class Solution {
    public int minOperations(int[] target, int[] arr) {
        int n = target.length;
        Map<Integer, Integer> map = new HashMap<>(n);
        for (int i = 0; i < n; ++i) {
            map.put(target[i], i);
        }
        var seq = new TreeSet<Integer>();
        for (int x : arr) {
            Integer i = map.get(x);
            if (i == null) {
                continue;
            }
            if (!seq.isEmpty() && seq.getLast() >= i) {
                int k = seq.ceiling(i);
                seq.remove(k);
            }
            seq.add(i);
        }
        return n - seq.size();
    }
}
// @lc code=end

