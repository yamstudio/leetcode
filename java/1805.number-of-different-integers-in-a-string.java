/*
 * @lc app=leetcode id=1805 lang=java
 *
 * [1805] Number of Different Integers in a String
 */

import java.util.HashSet;
import java.util.Set;

// @lc code=start
class Solution {
    public int numDifferentIntegers(String word) {
        int n = word.length();
        Set<String> nums = new HashSet<>();
        StringBuilder sb = new StringBuilder();
        char prev = 'z';
        for (int i = 0; i <= n; ++i) {
            char curr = i == n ? 'z' : word.charAt(i);
            if (isDigit(curr)) {
                if (curr != '0' || sb.length() > 0) {
                    sb.append(curr);
                }
            } else {
                if (isDigit(prev)) {
                    nums.add(sb.toString());
                    if (sb.length() > 0) {
                        sb.delete(0, sb.length());
                    }
                }
            }
            prev = curr;
        }
        return nums.size();
    }

    private static boolean isDigit(char c) {
        return c >= '0' && c <= '9';
    }
}
// @lc code=end

