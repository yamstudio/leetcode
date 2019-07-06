/*
 * @lc app=leetcode id=42 lang=csharp
 *
 * [42] Trapping Rain Water
 */
public class Solution {
    public int Trap(int[] height) {
        int[] leftMax = new int[height.Length];
        int rightMax = 0, ret = 0;
        for (int i = 1; i < height.Length; ++i) {
            leftMax[i] = Math.Max(leftMax[i - 1], height[i - 1]);
        }
        for (int i = height.Length - 2; i > 0; --i) {
            rightMax = Math.Max(rightMax, height[i + 1]);
            int wall = Math.Min(leftMax[i], rightMax);
            if (wall > height[i]) {
                ret += wall - height[i];
            }
        }
        return ret;
    }
}

