/*
 * @lc app=leetcode id=315 lang=csharp
 *
 * [315] Count of Smaller Numbers After Self
 */

using System.Collections.Generic;

public class Solution {
    public IList<int> CountSmaller(int[] nums) {
        int n = nums.Length;
        List<int> sorted = new List<int>(n), ret = new List<int>(n);
        for (int i = n - 1; i >= 0; --i) {
            int num = nums[i], left = 0, right = n - i - 1;
            while (left < right) {
                int mid = (left + right) / 2;
                if (sorted[mid] < num) {
                    left = mid + 1;
                } else {
                    right = mid;
                }
            }
            ret.Add(right);
            sorted.Insert(right, num);
        }
        ret.Reverse();
        return ret;
    }
}

