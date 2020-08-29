/*
 * @lc app=leetcode id=1095 lang=csharp
 *
 * [1095] Find in Mountain Array
 */

// @lc code=start
/**
 * // This is MountainArray's API interface.
 * // You should not implement it, or speculate about its implementation
 * class MountainArray {
 *     public int Get(int index) {}
 *     public int Length() {}
 * }
 */

class Solution {
    public int FindInMountainArray(int target, MountainArray mountainArr) {
        int left = 0, n = mountainArr.Length(), right = n - 1, peak;
        while (left < right) {
            int mid = left + (right - left) / 2, m = mountainArr.Get(mid), m1 = mountainArr.Get(mid + 1);
            if (m < m1) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        if (mountainArr.Get(left) == target) {
            return left;
        }
        peak = left;
        left = 0;
        right = peak;
        while (left < right) {
            int mid = left + (right - left) / 2, m = mountainArr.Get(mid);
            if (m == target) {
                return mid;
            } else if (m < target) {
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        if (mountainArr.Get(left) == target) {
            return left;
        }
        left = peak + 1;
        right = n - 1;
        while (left < right) {
            int mid = left + (right - left) / 2, m = mountainArr.Get(mid);
            if (m == target) {
                return mid;
            } else if (m > target) {
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        if (mountainArr.Get(right) == target) {
            return right;
        }
        return -1;
    }
}
// @lc code=end

