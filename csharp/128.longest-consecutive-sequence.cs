/*
 * @lc app=leetcode id=128 lang=csharp
 *
 * [128] Longest Consecutive Sequence
 */

using System.Collections.Generic;

public class Solution {
    public int LongestConsecutive(int[] nums) {
        IDictionary<int, int> map = new Dictionary<int, int>(nums.Length);
        int ret = 0;
        foreach (int curr in nums) {
            if (map.ContainsKey(curr)) {
                continue;
            }
            if (map.ContainsKey(curr - 1)) {
                int val = map[curr - 1];
                if (val > 0) {
                    continue;
                }
                int len = -val + 1;
                map[curr] = -len;
                map[curr - len] = len;
                ret = Math.Max(ret, len + 1);
            }
            if (map.ContainsKey(curr + 1)) {
                int val = map[curr + 1], len;
                if (val < 0) {
                    continue;
                }
                if (map.ContainsKey(curr)) {
                    len = -map[curr] + val + 1;
                    map[curr + map[curr]] = len;
                    map[curr + 1 + val] = -len;
                } else {
                    len = val + 1;
                    map[curr] = len;
                    map[curr + len] = -len;
                }
                ret = Math.Max(ret, len + 1);
                continue;
            }
            if (!map.ContainsKey(curr)) {
                map[curr] = 0;
                ret = Math.Max(ret, 1);
            }
        }
        return ret;
    }
}

