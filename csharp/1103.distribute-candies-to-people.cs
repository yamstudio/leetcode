/*
 * @lc app=leetcode id=1103 lang=csharp
 *
 * [1103] Distribute Candies to People
 */

using System;

// @lc code=start
public class Solution {
    public int[] DistributeCandies(int candies, int num_people) {
        var ret = new int[num_people];
        int i = 0, acc = 1;
        while (candies > 0) {
            int c = Math.Min(acc++, candies);
            candies -= c;
            ret[i] += c;
            i = (i + 1) % num_people;
        }
        return ret;
    }
}
// @lc code=end

