/*
 * @lc app=leetcode id=881 lang=csharp
 *
 * [881] Boats to Save People
 */

using System;

// @lc code=start
public class Solution {
    public int NumRescueBoats(int[] people, int limit) {
        int right = people.Length - 1, left = 0, ret = 0;
        Array.Sort(people);
        while (right >= left) {
            if (people[right--] + people[left] <= limit) {
                ++left;
            }
            ++ret;
        }
        return ret;
    }
}
// @lc code=end

