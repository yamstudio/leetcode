/*
 * @lc app=leetcode id=1356 lang=java
 *
 * [1356] Sort Integers by The Number of 1 Bits
 */

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

// @lc code=start

class Solution {
    public int[] sortByBits(int[] arr) {
        int n = arr.length;
        List<Pair> pairs = new ArrayList<>(n);
        for (int i = 0; i < n; ++i) {
            int num = arr[i];
            pairs.add(new Pair(count(num), num));
        }
        Collections.sort(pairs);
        int[] ret = new int[n];
        for (int i = 0; i < n; ++i) {
            ret[i] = pairs.get(i).val();
        }
        return ret;
    }

    private static int count(int num) {
        int ret = 0;
        while (num != 0) {
            ret += num & 1;
            num >>= 1;
        }
        return ret;
    }

    private record Pair(int ones, int val) implements Comparable<Pair> {
        @Override
        public int compareTo(Pair other) {
            if (ones != other.ones) {
                return ones - other.ones;
            }
            return val - other.val;
        }
        
    }
}
// @lc code=end

