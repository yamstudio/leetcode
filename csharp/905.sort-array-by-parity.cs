/*
 * @lc app=leetcode id=905 lang=csharp
 *
 * [905] Sort Array By Parity
 */

// @lc code=start
public class Solution {
    public int[] SortArrayByParity(int[] A) {
        int n = A.Length, j = -1;
        for (int i = 0; i < n; ++i) {
            int val = A[i];
            if (val % 2 == 1) {
                if (j < 0) {
                    j = i;
                }
            } else {
                if (j < 0) {
                    continue;
                }
                if (j < i) {
                    A[i] = A[j];
                    A[j] = val;
                }
                j++;
            }
        }
        return A;
    }
}
// @lc code=end

