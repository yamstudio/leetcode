/*
 * @lc app=leetcode id=457 lang=csharp
 *
 * [457] Circular Array Loop
 */
public class Solution {
    private static int Next(int[] nums, int n, int i) {
        return ((i + nums[i]) % n + n) % n;
    }

    public bool CircularArrayLoop(int[] nums) {
        int n = nums.Length;
        for (int i = 0; i < n; ++i) {
            if (nums[i] == 0) {
                continue;
            }
            int slow = i, fast = Next(nums, n, i), sign = nums[i] > 0 ? 1 : -1;
            while (sign * nums[fast] > 0 && sign * nums[Next(nums, n, fast)] > 0) {
                if (slow == fast) {
                    if (slow != Next(nums, n, slow)) {
                        return true;
                    }
                    break;
                }
                slow = Next(nums, n, slow);
                fast = Next(nums, n, Next(nums, n, fast));
            }
            slow = i;
            while (sign * nums[slow] > 0) {
                fast = Next(nums, n, slow);
                nums[slow] = 0;
                slow = fast;
            }
        }
        return false;
    }
}

