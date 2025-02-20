/*
 * @lc app=leetcode id=1371 lang=java
 *
 * [1371] Find the Longest Substring Containing Vowels in Even Counts
 */

// @lc code=start
class Solution {
    public int findTheLongestSubstring(String s) {
        int n = s.length(), ret = 0, acc = 0;
        int[] first = new int[1 << 5];
        first[0] = 1;
        for (int k = 0; k < n; ++k) {
            char c = s.charAt(k);
            if (c == 'a') {
                acc ^= (1 << 0);
            } else if (c == 'e') {
                acc ^= (1 << 1);
            } else if (c == 'i') {
                acc ^= (1 << 2);
            } else if (c == 'o') {
                acc ^= (1 << 3);
            } else if (c == 'u') {
                acc ^= (1 << 4);
            }
            if (first[acc] != 0) {
                ret = Math.max(ret, k + 2 - first[acc]);
            } else {
                first[acc] = k + 2;
            }
        }
        return ret;
    }
}
// @lc code=end

