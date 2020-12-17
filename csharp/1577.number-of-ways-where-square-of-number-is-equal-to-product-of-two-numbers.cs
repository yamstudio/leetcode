/*
 * @lc app=leetcode id=1577 lang=csharp
 *
 * [1577] Number of Ways Where Square of Number Is Equal to Product of Two Numbers
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static int Count(IDictionary<int, int> nums, IDictionary<int, int> other) {
        int ret = 0;
        foreach (var tuple in nums) {
            int num = tuple.Key;
            long t = (long)num * (long)num;
            for (int i = 1; i <= num; ++i) {
                if (t % i != 0 || !other.TryGetValue(i, out var c1) || !other.TryGetValue((int)(t / (long)i), out var c2)) {
                    continue;
                }
                if (i == num) {
                    ret += tuple.Value * c1 * (c1 - 1) / 2;
                } else {
                    ret += tuple.Value * c1 * c2;
                }
            }
        }
        return ret;
    }

    public int NumTriplets(int[] nums1, int[] nums2) {
        IDictionary<int, int> count1 = nums1.GroupBy(x => x, (x, a) => (Num: x, Count: a.Count())).ToDictionary(t => t.Num, t => t.Count), count2 = nums2.GroupBy(x => x, (x, a) => (Num: x, Count: a.Count())).ToDictionary(t => t.Num, t => t.Count);
        return Count(count1, count2) + Count(count2, count1);
    }
}
// @lc code=end

