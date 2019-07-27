/*
 * @lc app=leetcode id=135 lang=csharp
 *
 * [135] Candy
 */

using System.Linq;

public class Solution {
    public int Candy(int[] ratings) {
        int n = ratings.Length;
        if (n == 0) {
            return 0;
        }
        int[] count = new int[n];
        count[0] = 1;
        for (int i = 1; i < n; ++i) {
            if (ratings[i] > ratings[i - 1]) {
                count[i] = count[i - 1] + 1;
            } else {
                count[i] = 1;
            }
        }
        for (int i = n - 2; i >= 0; --i) {
            if (ratings[i] > ratings[i + 1]) {
                count[i] = Math.Max(count[i], count[i + 1] + 1);
            }
        }
        return count.Aggregate(0, (ret, x) => ret + x);
    }
}

