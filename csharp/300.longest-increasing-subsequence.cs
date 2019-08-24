/*
 * @lc app=leetcode id=300 lang=csharp
 *
 * [300] Longest Increasing Subsequence
 */

using System.Collections.Generic;

public class Solution {
    public int LengthOfLIS(int[] nums) {
        IList<int> list = new List<int>();
        foreach (int num in nums) {
            int left = 0, right = list.Count;
            while (left < right) {
                int mid = left + (right - left) / 2;
                if (list[mid] < num) {
                    left = mid + 1;
                } else {
                    right = mid;
                }
            }
            if (right >= list.Count) {
                list.Add(num);
            } else {
                list[right] = num;
            }
        }
        return list.Count;
    }
}

