/*
 * @lc app=leetcode id=287 lang=csharp
 *
 * [287] Find the Duplicate Number
 */

using System.Linq;

public class Solution {
    public int FindDuplicate(int[] nums) {
        int slow = 0, fast = 0, head = 0;
        do {
            slow = nums[slow];
            fast = nums[nums[fast]];
        } while (slow != fast);
        do {
            slow = nums[slow];
            head = nums[head];
        } while (slow != head);
        return slow;
    }
}

