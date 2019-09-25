/*
 * @lc app=leetcode id=456 lang=csharp
 *
 * [456] 132 Pattern
 */
public class Solution {
    public bool Find132pattern(int[] nums) {
        int n = nums.Length, min = int.MaxValue;
        for (int i = 0; i < n; ++i) {
            int curr = nums[i];
            min = Math.Min(min, curr);
            if (curr == min) {
                continue;
            }
            for (int j = i + 1; j < n; ++j) {
                if (min < nums[j] && nums[j] < curr) {
                    return true;
                }
            }
        }
        return false;
    }
}

