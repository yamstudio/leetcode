/*
 * @lc app=leetcode id=1400 lang=java
 *
 * [1400] Construct K Palindrome Strings
 */

// @lc code=start
class Solution {
    public boolean canConstruct(String s, int k) {
        int n = s.length(), odd = 0;
        if (n < k) {
            return false;
        }
        int[] count = new int[26];
        for (int i = 0; i < n; ++i) {
            int v = ++count[s.charAt(i) - 'a'];
            if (v % 2 == 1) {
                ++odd;
            } else {
                --odd;
            }
        }
        return odd <= k;
    }
}
// @lc code=end

