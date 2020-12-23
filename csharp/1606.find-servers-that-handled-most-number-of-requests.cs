/*
 * @lc app=leetcode id=1606 lang=csharp
 *
 * [1606] Find Servers That Handled Most Number of Requests
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static int BinarySearch(SortedList<int, int> reqs, int b) {
        IList<int> keys = reqs.Keys;
        int l = 0, r = keys.Count;
        while (l < r) {
            int m = l + (r - l) / 2;
            if (keys[m] >= b) {
                r = m;
            } else {
                l = m + 1;
            }
        }
        if (l >= keys.Count) {
            return -1;
        }
        return keys[l];
    }

    public IList<int> BusiestServers(int k, int[] arrival, int[] load) {
        var reqs = new SortedList<int, int>();
        int[] count = new int[k], end = new int[k];
        int n = load.Length, max = 0;
        var ret = new List<int>();
        for (int i = 0, p = 0; i < n || i - p <= k; ++i) {
            if (i < n) {
                reqs[arrival[i]] = load[i];
            }
            int l = BinarySearch(reqs, end[i % k]);
            while (l != -1) {
                p = i;
                ++count[i % k];
                end[i % k] = l + reqs[l];
                reqs.Remove(l);
                l = BinarySearch(reqs, end[i % k]);
            }
        }
        for (int i = 0; i < k; ++i) {
            if (count[i] > max) {
                max = count[i];
                ret.Clear();
                ret.Add(i);
            } else if (max == count[i]) {
                ret.Add(i);
            }
        }
        return ret;
    }
}
// @lc code=end

