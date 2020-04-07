/*
 * @lc app=leetcode id=852 lang=csharp
 *
 * [852] Peak Index in a Mountain Array
 */

// @lc code=start
public class Solution {
    public int PeakIndexInMountainArray(int[] A) {
        int left = 0, right = A.Length - 1;
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (A[mid] < A[mid + 1]) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    }
}
// @lc code=end

