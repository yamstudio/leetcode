/*
 * @lc app=leetcode id=1331 lang=java
 *
 * [1331] Rank Transform of an Array
 */

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

// @lc code=start

import static java.util.Comparator.comparingInt;

class Solution {
    public int[] arrayRankTransform(int[] arr) {
        int n = arr.length, rank = 0;
        int[] ret = new int[n];
        List<Pair> sorted = new ArrayList<>(n);
        for (int i = 0; i < n; ++i) {
            sorted.add(new Pair(arr[i], i));
        }
        Collections.sort(sorted, comparingInt(Pair::val));
        Pair prev = new Pair(Integer.MIN_VALUE, -1);
        for (int i = 0; i < n; ++i) {
            var curr = sorted.get(i);
            if (curr.val != prev.val) {
                ++rank;
            }
            ret[curr.index] = rank;
            prev = curr;
        }
        return ret;
    }

    private record Pair(int val, int index) {}
}
// @lc code=end

