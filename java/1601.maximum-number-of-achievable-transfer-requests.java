/*
 * @lc app=leetcode id=1601 lang=java
 *
 * [1601] Maximum Number of Achievable Transfer Requests
 */

// @lc code=start
class Solution {
    public int maximumRequests(int n, int[][] requests) {
        return maximumRequests(requests, 0, 0, new int[n]);
    }

    private static int maximumRequests(int[][] requests, int i, int acc, int[] diff) {
        if (i == requests.length) {
            int n = diff.length, j;
            for (j = 0; j < n && diff[j] == 0; ++j);
            if (j == n) {
                return acc;
            } else {
                return 0;
            }
        }
        int l = requests[i][0], r = requests[i][1];
        ++diff[l];
        --diff[r];
        int ret = maximumRequests(requests, i + 1, acc + 1, diff);
        --diff[l];
        ++diff[r];
        ret = Math.max(ret, maximumRequests(requests, i + 1, acc, diff));
        return ret;
    }
}
// @lc code=end

