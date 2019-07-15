/*
 * @lc app=leetcode id=88 lang=csharp
 *
 * [88] Merge Sorted Array
 */
public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        int i = m - 1, j = n - 1, k = m + n - 1;
        while (j >= 0) {
            nums1[k--] = (i >= 0 && nums1[i] >= nums2[j]) ? nums1[i--] : nums2[j--];
        }
    }
}

