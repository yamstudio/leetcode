/*
 * @lc app=leetcode id=961 lang=csharp
 *
 * [961] N-Repeated Element in Size 2N Array
 */

// @lc code=start
public class Solution {
    public int RepeatedNTimes(int[] A) {
        int n = A.Length;
        for (int i = 0; i < n; i += 2) {
            if (A[i] == A[i + 1]) {
                return A[i];
            }
        }
        if (A[0] == A[2] || A[0] == A[3]) {
            return A[0];
        }
        return A[1];
    }
}
// @lc code=end

