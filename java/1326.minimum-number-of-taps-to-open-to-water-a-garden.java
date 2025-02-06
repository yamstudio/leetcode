/*
 * @lc app=leetcode id=1326 lang=java
 *
 * [1326] Minimum Number of Taps to Open to Water a Garden
 */

// @lc code=start
class Solution {
    public int minTaps(int n, int[] ranges) {
        int[] rights = new int[n + 1];
        int k = ranges.length;
        for (int i = 0; i < k; ++i) {
            int l = Math.max(0, i - ranges[i]), r = i + ranges[i];
            if (r == i) {
                continue;
            }
            rights[l] = Math.max(rights[l], r);
        }
        int curr = 0, r = 0, ret = 0;
        while (curr <= n && r < n) {
            ++ret;
            int nr = r;
            while (curr <= n && curr <= r) {
                nr = Math.max(nr, rights[curr]);
                ++curr;
            }
            if (nr == r) {
                return -1;
            }
            r = nr;
        }
        return ret;
    }
}
// @lc code=end

