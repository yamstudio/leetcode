/*
 * @lc app=leetcode id=164 lang=csharp
 *
 * [164] Maximum Gap
 */
public class Solution {
    public int MaximumGap(int[] nums) {
        int n = nums.Length;
        if (n < 2) {
            return 0;
        }
        int min = int.MaxValue, max = int.MinValue;
        foreach (int num in nums) {
            min = Math.Min(min, num);
            max = Math.Max(max, num);
        }
        int size = (max - min) / n + 1, count = (max - min) / size + 1;
        int[] mins = new int[count], maxs = new int[count];
        for (int i = 0; i < count; ++i) {
            mins[i] = int.MaxValue;
            maxs[i] = int.MinValue;
        }
        foreach (int num in nums) {
            int i = (num - min) / size;
            mins[i] = Math.Min(mins[i], num);
            maxs[i] = Math.Max(maxs[i], num);
        }
        int ret = 0, prev = 0;
        for (int i = 1; i < count; ++i) {
            if (mins[i] == int.MaxValue) {
                continue;
            }
            ret = Math.Max(ret, mins[i] - maxs[prev]);
            prev = i;
        }
        return ret;
    }
}

