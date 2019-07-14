/*
 * @lc app=leetcode id=85 lang=csharp
 *
 * [85] Maximal Rectangle
 */
public class Solution {
    public int MaximalRectangle(char[][] matrix) {
        if (matrix.Length == 0) {
            return 0;
        }
        int cols = matrix[0].Length, top, ret = 0;
        int[] heights = new int[cols + 2], stack = new int[cols + 3];
        heights[0] = -1;
        heights[cols + 1] = -1;

        foreach (char[] row in matrix) {
            stack[0] = 0;
            top = 0;
            for (int i = 1; i <= cols; ++i) {
                heights[i] = row[i - 1] == '1' ? heights[i] + 1 : 0;
            }
            for (int i = 0; i < cols + 2; ++i) {
                while (heights[i] < heights[stack[top]]) {
                    int h = heights[stack[top--]];
                    ret = Math.Max(ret, h * (i - 1 - stack[top]));
                }
                stack[++top] = i;
            }
        }
        return ret;
    }
}

