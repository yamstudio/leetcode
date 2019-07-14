/*
 * @lc app=leetcode id=84 lang=csharp
 *
 * [84] Largest Rectangle in Histogram
 */
public class Solution {
    public int LargestRectangleArea(int[] heights) {
        int n = heights.Length, top, ret = 0;
        int[] hs = new int[n + 2], stack = new int[n + 3];
        hs[0] = -1;
        for (int i = 0; i < n; ++i) {
            hs[i + 1] = heights[i];
        }
        hs[n + 1] = -1;
        n = n + 2;
        
        stack[0] = 0;
        top = 0;
        for (int i = 0; i < n; ++i) {
            int curr = hs[i];
            while (curr < hs[stack[top]]) {
                int h = hs[stack[top--]];
                ret = Math.Max(ret, h * (i - 1 - stack[top]));
            }
            stack[++top] = i;
        }
        return ret;
    }
}

