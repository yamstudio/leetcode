/*
 * @lc app=leetcode id=528 lang=csharp
 *
 * [528] Random Pick with Weight
 */

using System;

// @lc code=start
public class Solution {

    private int[] Sums;
    private int Total;
    private Random Random;

    public Solution(int[] w) {
        int n = w.Length;
        Total = 0;
        Sums = new int[n];
        Random = new Random();
        for (int i = 0; i < n; ++i) {
            Total += w[i];
            Sums[i] = Total;
        }
    }
    
    public int PickIndex() {
        int left = 0, right = Sums.Length - 1, rand = Random.Next(1, Total + 1);
        while (left < right) {
            int mid = (left + right) / 2;
            if (Sums[mid] < rand) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return left;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(w);
 * int param_1 = obj.PickIndex();
 */
// @lc code=end

