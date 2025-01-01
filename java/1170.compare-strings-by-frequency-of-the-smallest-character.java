/*
 * @lc app=leetcode id=1170 lang=java
 *
 * [1170] Compare Strings by Frequency of the Smallest Character
 */

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

// @lc code=start

class Solution {
    public int[] numSmallerByFrequency(String[] queries, String[] words) {
        int n = words.length, k = queries.length;
        List<Pair> vals = new ArrayList<>(n);
        for (int i = 0; i < n; ++i) {
            vals.add(new Pair(f(words[i]), i));
        }
        Collections.sort(vals);
        int[] ret = new int[k];
        for (int i = 0; i < k; ++i) {
            int val = f(queries[i]);
            int index = Collections.binarySearch(vals, new Pair(val, n + 1));
            ret[i] = n - (-index - 1);
        }
        return ret;
    }

    private static int f(String s) {
        char min = 'z';
        int ret = 0, n = s.length();
        for (int i = 0; i < n; ++i) {
            char c = s.charAt(i);
            if (c > min) {
                continue;
            }
            if (c == min) {
                ++ret;
            } else {
                min = c;
                ret = 1;
            }
        }
        return ret;
    }

    private record Pair(int val, int i) implements Comparable<Pair> {
        @Override
        public int compareTo(Pair other) {
            if (val == other.val) {
                return i - other.i;
            }
            return val - other.val;
        }
    }
}
// @lc code=end

