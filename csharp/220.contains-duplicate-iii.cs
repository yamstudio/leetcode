/*
 * @lc app=leetcode id=220 lang=csharp
 *
 * [220] Contains Duplicate III
 */

using System.Collections.Generic;

public class Solution {
    public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t) {
        ++k;
        var set = new SortedSet<long>();
        int n = nums.Length;
        for (int i = 0; i < n; ++i) {
            if (i >= k) {
                set.Remove((long) nums[i - k]);
            }
            long num = (long) nums[i];
            if (t >= 0 && set.GetViewBetween(num - t, num + t).Count > 0) {
                return true;
            }
            set.Add(num);
        }
        return false;
    }
}

