/*
 * @lc app=leetcode id=228 lang=csharp
 *
 * [228] Summary Ranges
 */

using System;

public class Solution {
    public IList<string> SummaryRanges(int[] nums) {
        if (nums.Length == 0) {
            return Array.Empty<string>();
        }
        var ret = new List<string>();
        int start = nums[0], end = start;
        for (int i = 1; i < nums.Length; ++i) {
            int num = nums[i];
            if (num == end + 1) {
                ++end;
            } else {
                ret.Add(start == end ? start.ToString() : $"{start}->{end}");
                start = num;
                end = num;
            }
        }
        ret.Add(start == end ? start.ToString() : $"{start}->{end}");
        return ret;
    }
}

