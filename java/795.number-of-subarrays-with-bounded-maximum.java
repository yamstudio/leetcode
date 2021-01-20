/*
 * @lc app=leetcode id=795 lang=java
 *
 * [795] Number of Subarrays with Bounded Maximum
 */

// @lc code=start
class Solution {
    public int numSubarrayBoundedMax(int[] A, int L, int R) {
        int n = A.length, ret = 0, l = -1, r = -1;
        for (int i = 0; i < n; ++i) {
            if (A[i] > R) {
                l = i;
                r = i;
                continue;
            }
            if (A[i] >= L) {
                r = i;
            }
            ret += r - l;
        }
        return ret;
    }
}
// @lc code=end

