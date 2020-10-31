/*
 * @lc app=leetcode id=1395 lang=csharp
 *
 * [1395] Count Number of Teams
 */

// @lc code=start
public class Solution {
    public int NumTeams(int[] rating) {
        int ret = 0, n = rating.Length;
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

