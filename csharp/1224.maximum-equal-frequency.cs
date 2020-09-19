/*
 * @lc app=leetcode id=1224 lang=csharp
 *
 * [1224] Maximum Equal Frequency
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int MaxEqualFreq(int[] nums) {
        var count = new Dictionary<int, int>();
        var prefixCount = new Dictionary<int, int>();
        int ret = 0, n = nums.Length;
        for (int i = 0; i < n; ++i) {
            int curr = nums[i];
            if (count.TryGetValue(curr, out int c)) {
                if (prefixCount[c] == 1) {
                    prefixCount.Remove(c);
                } else {
                    --prefixCount[c];
                }
            } else {
                c = 0;
            }
            count[curr] = c + 1;
            if (prefixCount.TryGetValue(c + 1, out var t)) {
                prefixCount[c + 1] = t + 1;
            } else {
                prefixCount[c + 1] = 1;
            }
            if (prefixCount.Count > 2) {
                continue;
            }
            int l = -1, r = -1;
            foreach (int k in prefixCount.Keys) {
                if (l < 0) {
                    l = k;
                } else {
                    r = k;
                }
            }
            if (r == -1) {
                if (l == 1 || prefixCount[l] == 1) {
                    ret = i + 1;
                }
                continue;
            }
            if (l > r) {
                int tmp = r;
                r = l;
                l = tmp;
            }
            if ((l == 1 && prefixCount[1] == 1) || (l == r - 1 && prefixCount[r] == 1)) {
                ret = i + 1;
            }
        }
        return ret;
    }
}
// @lc code=end

