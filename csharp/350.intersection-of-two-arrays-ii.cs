/*
 * @lc app=leetcode id=350 lang=csharp
 *
 * [350] Intersection of Two Arrays II
 */

using System.Collections.Generic;

public class Solution {
    public int[] Intersect(int[] nums1, int[] nums2) {
        var map = new Dictionary<int, int>();
        var ret = new List<int>();
        foreach (int num in nums1) {
            map[num] = 1 + (map.ContainsKey(num) ? map[num] : 0);
        }
        foreach (int num in nums2) {
            if (map.ContainsKey(num) && map[num] > 0) {
                --map[num];
                ret.Add(num);
            }
        }
        return ret.ToArray();
    }
}

