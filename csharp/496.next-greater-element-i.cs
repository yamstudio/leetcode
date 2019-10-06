/*
 * @lc app=leetcode id=496 lang=csharp
 *
 * [496] Next Greater Element I
 */

// @lc code=start
public class Solution {
    public int[] NextGreaterElement(int[] nums1, int[] nums2) {
        int m = nums1.Length, n = nums2.Length;
        int[] ret = new int[m];
        for (int i = 0; i < m; ++i) {
            int num = nums1[i], j;
            for (j = 0; j < n && nums2[j] != num; ++j);
            for (j++; j < n && nums2[j] <= num; ++j);
            ret[i] = j == n ? -1 : nums2[j];
        }
        return ret;
    }
}
// @lc code=end

