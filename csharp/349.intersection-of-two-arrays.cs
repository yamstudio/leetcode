/*
 * @lc app=leetcode id=349 lang=csharp
 *
 * [349] Intersection of Two Arrays
 */

using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] Intersection(int[] nums1, int[] nums2) {
        return nums2.Where((new HashSet<int>(nums1)).Contains).Distinct().ToArray();
    }
}

