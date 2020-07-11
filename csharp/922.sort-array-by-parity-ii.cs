/*
 * @lc app=leetcode id=922 lang=csharp
 *
 * [922] Sort Array By Parity II
 */

// @lc code=start
public class Solution {
    public int[] SortArrayByParityII(int[] A) {
        int i = 0, j = 1, n = A.Length;
        while (i < n) {
            int x = A[i];
            if (x % 2 == 1) {
                while (A[j] % 2 == 1) {
                    j += 2;
                }
                A[i] = A[j];
                A[j] = x;
            }
            i += 2;
        }
        return A;
    }
}
// @lc code=end

