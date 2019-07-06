/*
 * @lc app=leetcode id=41 lang=csharp
 *
 * [41] First Missing Positive
 */
public class Solution {
    public int FirstMissingPositive(int[] nums) {
        int i = 0;
        while (i < nums.Length) {
            int tmp = nums[i];
            if (tmp != i + 1 && tmp > 0 && tmp <= nums.Length && tmp != nums[tmp - 1]) {
                nums[i] = nums[tmp - 1];
                nums[tmp - 1] = tmp;

            } else {
                ++i;
            }
        }
        for (i = 0; i < nums.Length && nums[i] == i + 1; ++i);
        return i + 1;
    }
}

