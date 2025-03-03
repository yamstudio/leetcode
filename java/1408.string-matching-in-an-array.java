/*
 * @lc app=leetcode id=1408 lang=java
 *
 * [1408] String Matching in an Array
 */

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

// @lc code=start
class Solution {
    public List<String> stringMatching(String[] words) {
        List<String> ret = new ArrayList<>();
        String[] sorted = Arrays
            .stream(words)
            .sorted(java.util.Comparator.comparingInt(String::length))
            .toArray(String[]::new);
        int n = sorted.length;
        for (int i = n - 1; i >= 0; --i) {
            String curr = sorted[i];
            for (int j = i + 1; j < n; ++j) {
                if (sorted[j].contains(curr)) {
                    ret.add(curr);
                    break;
                }
            }
        }
        return ret;
    }
}
// @lc code=end

