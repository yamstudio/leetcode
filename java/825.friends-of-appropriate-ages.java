/*
 * @lc app=leetcode id=825 lang=java
 *
 * [825] Friends Of Appropriate Ages
 */

// @lc code=start
class Solution {
    public int numFriendRequests(int[] ages) {
        int[] count = new int[121];
        int ret = 0;
        for (int age : ages) {
            ++count[age];
        }
        for (int i = 1; i <= 120; ++i) {
            int t = count[i];
            count[i] += count[i - 1];
            if (i >= 15 && t >= 0) {
                int p = count[i] - count[i / 2 + 7];
                ret += p * t - t;
            }
        }
        return ret;
    }
}
// @lc code=end

