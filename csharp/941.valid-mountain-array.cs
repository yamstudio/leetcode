/*
 * @lc app=leetcode id=941 lang=csharp
 *
 * [941] Valid Mountain Array
 */

// @lc code=start
public class Solution {
    public bool ValidMountainArray(int[] A) {
        int n = A.Length, i;
        for (i = 0; i < n - 1 && A[i] < A[i + 1]; ++i) {}
        if (i == 0 || i == n - 1) {
            return false;
        }
        for (; i < n - 1 && A[i] > A[i + 1]; ++i) {}
        return i == n - 1;
    }
}
// @lc code=end

