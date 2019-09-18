/*
 * @lc app=leetcode id=421 lang=csharp
 *
 * [421] Maximum XOR of Two Numbers in an Array
 */

using System.Collections.Generic;

public class Solution {
    public int FindMaximumXOR(int[] nums) {
        ISet<int> set = new HashSet<int>(nums.Length);
        int ret = 0, mask = 0;
        for (int i = 31; i >= 0; --i) {
            mask |= 1 << i;
            foreach (int num in nums) {
                set.Add(num & mask);
            }
            int find = ret | (1 << i);
            foreach (int num in set) {
                if (set.Contains(num ^ find)) {
                    ret = find;
                    break;
                }
            }
            set.Clear();
        }
        return ret;
    }
}

