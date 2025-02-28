/*
 * @lc app=leetcode id=1395 lang=java
 *
 * [1395] Count Number of Teams
 */

// @lc code=start
class Solution {
    public int numTeams(int[] rating) {
        int n = rating.length, ret = 0;
        for (int i = 1; i < n - 1; ++i) {
            int v = rating[i], ll = 0, lg = 0, rl = 0, rg = 0;
            for (int j = 0; j < i; ++j) {
                if (rating[j] < v) {
                    ++ll;
                } else if (rating[j] > v) {
                    ++lg;
                }
            }
            for (int j = i + 1; j < n; ++j) {
                if (rating[j] < v) {
                    ++rl;
                } else if (rating[j] > v) {
                    ++rg;
                }
            }
            ret += ll * rg + lg * rl;
        }
        return ret;
    }
}
// @lc code=end

