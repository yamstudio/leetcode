/*
 * @lc app=leetcode id=60 lang=csharp
 *
 * [60] Permutation Sequence
 */

using System.Text;
using System.Collections.Generic;

public class Solution {
    public string GetPermutation(int n, int k) {
        int[] fact = new int[n];
        IList<int> nums = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9});
        StringBuilder sb = new StringBuilder();
        fact[0] = 1;
        for (int i = 1; i < n; ++i) {
            fact[i] = i * fact[i - 1];
        }
        --k;
        for (int i = n - 1; i >= 0; --i) {
            int j = k / fact[i];
            k %= fact[i];
            sb.Append(nums[j]);
            nums.RemoveAt(j);
        }
        return sb.ToString();
    }
}

