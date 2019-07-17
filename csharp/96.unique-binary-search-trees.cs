/*
 * @lc app=leetcode id=96 lang=csharp
 *
 * [96] Unique Binary Search Trees
 */
public class Solution {
    public int NumTrees(int n) {
        int[] count = new int[n + 1];
        count[0] = 1;
        for (int i = 1; i <= n; ++i) {
            for (int j = 0; j < i; ++j) {
                count[i] += count[j] * count[i - 1 - j];
            }
        }
        return count[n];
    }
}

