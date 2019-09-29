/*
 * @lc app=leetcode id=473 lang=csharp
 *
 * [473] Matchsticks to Square
 */

using System;

// @lc code=start
public class Solution {

    private static bool MakesquareRecurse(int[] nums, int[] sides, int curr, int length) {
        if (curr >= nums.Length) {
            return sides[0] == length && sides[1] == length && sides[2] == length;
        }
        int num = nums[curr];
        for (int i = 0; i < 4; ++i) {
            int side = sides[i];
            if ((i > 0 && side == sides[i - 1]) || side + num > length) {
                continue;
            }
            sides[i] = side + num;
            if (MakesquareRecurse(nums, sides, curr + 1, length)) {
                return true;
            }
            sides[i] = side;
        }
        return false;
    }

    public bool Makesquare(int[] nums) {
        if (nums.Length < 4) {
            return false;
        }
        int length = 0;
        foreach (int num in nums) {
            length += num;
        }
        if (length % 4 != 0) {
            return false;
        }
        Array.Sort(nums);
        return MakesquareRecurse(nums, new int[4], 0, length / 4);
    }
}
// @lc code=end

