/*
 * @lc app=leetcode id=1601 lang=csharp
 *
 * [1601] Maximum Number of Achievable Transfer Requests
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {

    private static int MaximumRequests(int n, int i, int count, int[] delta, int[][] requests) {
        if (i == requests.Length) {
            if (delta.All(x => x == 0)) {
                return count;
            }
            return 0;
        }
        int ret, f = requests[i][0], t = requests[i][1];
        delta[f]--;
        delta[t]++;
        ret = MaximumRequests(n, i + 1, 1 + count, delta, requests);
        delta[f]++;
        delta[t]--;
        ret = Math.Max(ret, MaximumRequests(n, i + 1, count, delta, requests));
        return ret;
    }

    public int MaximumRequests(int n, int[][] requests) {
        return MaximumRequests(n, 0, 0, new int[n], requests);
    }
}
// @lc code=end

