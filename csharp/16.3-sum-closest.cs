/*
 * @lc app=leetcode id=16 lang=csharp
 *
 * [16] 3Sum Closest
 */
public class Solution {
    public int ThreeSumClosest(int[] nums, int target) {
        int ret = nums[0] + nums[1] + nums[2], minDiff = Math.Abs(ret - target);
        Array.Sort(nums);
        for (int i = 0; i < nums.Length - 2; ++i) {
            int left = i + 1, right = nums.Length - 1, v = nums[i];
            if (i > 0 && v == nums[i - 1]) {
                continue;
            }
            while (left < right) {
                int vl = nums[left], vr = nums[right], sum = v + vl + vr, diff = Math.Abs(sum - target);
                if (minDiff > diff) {
                    minDiff = diff;
                    ret = sum;
                }
                
                if (sum < target) {
                    while (left < nums.Length && nums[left] == vl) {
                        ++left;
                    }
                } else {
                    while (right > i && nums[right] == vr) {
                        --right;
                    }
                }
            }
        }

        return ret;
    }
}

