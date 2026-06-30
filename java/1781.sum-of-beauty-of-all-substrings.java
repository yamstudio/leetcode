/*
 * @lc app=leetcode id=1781 lang=java
 *
 * [1781] Sum of Beauty of All Substrings
 */

// @lc code=start
class Solution {
    public int beautySum(String s) {
        int n = s.length(), ret = 0;
        for (int i = 0; i < n; ++i) {
            int[] count = new int[26];
            for (int j = i; j < n; ++j) {
                ++count[s.charAt(j) - 'a'];
                int max = 0, min = 501;
                for (int c = 0; c < 26; ++c) {
                    int v = count[c];
                    if (v == 0) {
                        continue;
                    }
                    max = Math.max(max, v);
                    min = Math.min(min, v);
                }
                ret += max - min;
            }
        }
        return ret;
    }
}
// @lc code=end

