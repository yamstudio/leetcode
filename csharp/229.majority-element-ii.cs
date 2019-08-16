/*
 * @lc app=leetcode id=229 lang=csharp
 *
 * [229] Majority Element II
 */

using System.Collections.Generic;

public class Solution {
    public IList<int> MajorityElement(int[] nums) {
        var ret = new List<int>(2);
        int n1 = 0, n2 = 0, c1 = 0, c2 = 0;
        foreach (int num in nums) {
            if (num == n1) {
                ++c1;
            } else if (num == n2) {
                ++c2;
            } else if (c1 == 0) {
                n1 = num;
                c1 = 1;
            } else if (c2 == 0) {
                n2 = num;
                c2 = 1;
            } else {
                --c1;
                --c2;
            }
        }
        c1 = 0;
        c2 = 0;
        foreach (int num in nums) {
            if (num == n1) {
                ++c1;
            } else if (num == n2) {
                ++c2;
            }
        }
        if (c1 > nums.Length / 3) {
            ret.Add(n1);
        }
        if (c2 > nums.Length / 3) {
            ret.Add(n2);
        }
        return ret;
    }
}

