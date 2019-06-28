/*
 * @lc app=leetcode id=4 lang=csharp
 *
 * [4] Median of Two Sorted Arrays
 */
public class Solution {

    private int findKth(int[] nums1, int from1, int len1, int[] nums2, int from2, int len2, int k) {
        if (len1 == 0) {
            return nums2[from2 + k - 1];
        }
        if (len2 == 0) {
            return nums1[from1 + k - 1];
        }

        int hlen1 = len1 / 2, hlen2 = len2 / 2;
        if (nums1[from1 + hlen1] <= nums2[from2 + hlen2]) {
            if (k > hlen1 + hlen2 + 1) {
                return findKth(nums1, from1 + hlen1 + 1, len1 - hlen1 - 1, nums2, from2, len2, k - hlen1 - 1);
            } else {
                return findKth(nums1, from1, len1, nums2, from2, hlen2, k);
            }
        } else {
            if (k > hlen1 + hlen2 + 1) {
                return findKth(nums1, from1, len1, nums2, from2 + hlen2 + 1, len2 - hlen2 - 1, k - hlen2 - 1);
            } else {
                return findKth(nums1, from1, hlen1, nums2, from2, len2, k);
            }
        }
    }

    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int len = nums1.Length + nums2.Length;
        if (len % 2 == 1) {
            return (double) findKth(nums1, 0, nums1.Length, nums2, 0, nums2.Length, len / 2 + 1);
        } else {
            return ((double) (findKth(nums1, 0, nums1.Length, nums2, 0, nums2.Length, len / 2 + 1) + findKth(nums1, 0, nums1.Length, nums2, 0, nums2.Length, len / 2))) / 2;
        }
    }
}

