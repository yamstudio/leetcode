/*
 * @lc app=leetcode id=11 lang=csharp
 *
 * [11] Container With Most Water
 */
public class Solution {
    public int MaxArea(int[] height) {
        int ret = 0, left = 0, right = height.Length - 1;
        while (left < right) {
            ret = Math.Max(ret, Math.Min(height[right], height[left]) * (right - left));
            if (height[left] < height[right]) {
                ++left;
            } else {
                --right;
            }
        }
        return ret;
    }
}

