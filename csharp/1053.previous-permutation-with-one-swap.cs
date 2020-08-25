/*
 * @lc app=leetcode id=1053 lang=csharp
 *
 * [1053] Previous Permutation With One Swap
 */

// @lc code=start
public class Solution {
    public int[] PrevPermOpt1(int[] A) {
        int n = A.Length, l, r;
        for (r = n - 1; r > 0 && A[r] >= A[r - 1]; --r);
        if (r == 0) {
            return A;
        }
        l = r - 1;
        int lv = A[l];
        for (int i = r + 1; i < n; ++i) {
            if (A[i] > A[i - 1] && A[i] < lv) {
                r = i;
            }
        }
        A[l] = A[r];
        A[r] = lv;
        return A;
    }
}
// @lc code=end

