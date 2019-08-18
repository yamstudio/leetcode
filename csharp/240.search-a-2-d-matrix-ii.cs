/*
 * @lc app=leetcode id=240 lang=csharp
 *
 * [240] Search a 2D Matrix II
 */
public class Solution {
    public bool SearchMatrix(int[,] matrix, int target) {
        int m = matrix.GetLength(0), n = matrix.GetLength(1), r = m - 1, c = 0;
        while (r >= 0 && c < n) {
            if (matrix[r, c] > target) {
                --r;
            } else if (matrix[r, c] == target) {
                return true;
            } else {
                ++c;
            }
        }
        return false;
    }
}

