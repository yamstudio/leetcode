/*
 * @lc app=leetcode id=825 lang=csharp
 *
 * [825] Friends Of Appropriate Ages
 */

using System;

// @lc code=start
public class Solution {
    public int NumFriendRequests(int[] ages) {
        int n = ages.Length, ret = 0;
        Array.Sort(ages);
        for (int i = 0; i < n; ++i) {
            int age = ages[i];
            double threshold = 0.5 * (double)age + 7;
            for (int j = i - 1; j >= 0; --j) {
                int k = ages[j];
                if ((double)k <= threshold) {
                    break;
                }
                if (k == age) {
                    ++ret;
                }
                ++ret;
            }
        }
        return ret;
    }
}
// @lc code=end

