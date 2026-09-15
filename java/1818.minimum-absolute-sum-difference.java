/*
 * @lc app=leetcode id=1818 lang=java
 *
 * [1818] Minimum Absolute Sum Difference
 */

import java.util.TreeSet;

// @lc code=start
class Solution {
    public int minAbsoluteSumDiff(int[] nums1, int[] nums2) {
        int n = nums1.length;
        long acc = 0, max = 0;
        var set = new TreeSet<Integer>();
        for (int x : nums1) {
            set.add(x);
        }
        for (int i = 0; i < n; ++i) {
            int a = nums1[i], b = nums2[i];
            long diff = Math.abs(a - b);
            if (diff > max) {
                Integer f = set.floor(b), c = set.ceiling(b);
                if (f != null) {
                    max = Math.max(max, diff - (long)(b - f));
                }
                if (c != null) {
                    max = Math.max(max, diff - (long)(c - b));
                }
            }
            acc += diff;
        }
        return (int)((acc - max) % 1000000007);
    }
}
// @lc code=end

