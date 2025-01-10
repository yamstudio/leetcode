/*
 * @lc app=leetcode id=1207 lang=java
 *
 * [1207] Unique Number of Occurrences
 */

// @lc code=start
class Solution {
    public boolean uniqueOccurrences(int[] arr) {
        int[] count = new int[2001];
        for (int a : arr) {
            ++count[a + 1000];
        }
        int[] oCount = new int[10000];
        for (int c : count) {
            if (c == 0) {
                continue;
            }
            if (oCount[c]++ > 0) {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

