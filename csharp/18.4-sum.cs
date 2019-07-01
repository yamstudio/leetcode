/*
 * @lc app=leetcode id=18 lang=csharp
 *
 * [18] 4Sum
 */
public class Solution {
    public IList<IList<int>> FourSum(int[] nums, int target) {
        IList<IList<int>> ret = new List<IList<int>>();
        Array.Sort(nums);
        for (int k = 0; k < nums.Length - 3; ++k) {
            int w = nums[k];
            if (k > 0 && w == nums[k - 1]) {
                continue;
            }
            for (int i = k + 1; i < nums.Length - 2; ++i) {
                int left = i + 1, right = nums.Length - 1, v = nums[i];
                if (i > k + 1 && v == nums[i - 1]) {
                    continue;
                }
                while (left < right) {
                    int vl = nums[left], vr = nums[right], sum = w + v + vl + vr;
                    if (sum == target) {
                        ret.Add(new List<int>(new int[] { w, v, vl, vr }));
                        while (left < nums.Length && nums[left] == vl) {
                            ++left;
                        }
                        while (right > i && nums[right] == vr) {
                            --right;
                        }
                    } else if (sum < target) {
                        ++left;
                    } else {
                        --right;
                    }
                }
            }
        }
        return ret;
    }
}

