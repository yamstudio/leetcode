/*
 * @lc app=leetcode id=1751 lang=java
 *
 * [1751] Maximum Number of Events That Can Be Attended II
 */

import java.util.TreeMap;

// @lc code=start

import static java.util.Arrays.sort;
import static java.util.Comparator.comparingInt;

class Solution {
    public int maxValue(int[][] events, int k) {
        int n = events.length;
        sort(events, comparingInt(e -> e[1]));
        var prev = new TreeMap<Integer, Integer>();
        var curr = new TreeMap<Integer, Integer>();
        prev.put(0, 0);
        curr.put(0, 0);
        while (k-- > 0) {
            for (var e : events) {
                int acc = prev.lowerEntry(e[0]).getValue();
                if (acc + e[2] > curr.lastEntry().getValue()) {
                    curr.put(e[1], acc + e[2]);
                }
            }
            var tmp = prev;
            prev = curr;
            curr = tmp;
            curr.tailMap(0, false).clear();
        }
        return prev.lastEntry().getValue();
    }
}
// @lc code=end

