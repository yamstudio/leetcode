/*
 * @lc app=leetcode id=48 lang=csharp
 *
 * [48] Rotate Image
 */
public class Solution {
    public void Rotate(int[][] matrix) {
        for (int l = 0; l < matrix.Length / 2; ++l) {
            int md = matrix.Length - 2 * l - 1;
            for (int d = 0; d < md; ++d) {
                int tmp = matrix[l][l + d];
                matrix[l][l + d] = matrix[l + md - d][l];
                matrix[l + md - d][l] = matrix[l + md][l + md - d];
                matrix[l + md][l + md - d] = matrix[l + d][l + md];
                matrix[l + d][l + md] = tmp;
            }
        }
    }
}

