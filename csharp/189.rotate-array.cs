/*
 * @lc app=leetcode id=189 lang=csharp
 *
 * [189] Rotate Array
 */
public class Solution {
    public void Rotate(int[] nums, int k) {
        int n = nums.Length;
        k = k % n;
        if (n == 0 || k == 0) {
            return;
        }
        int start = 0, prev, curr = nums[0], i = 0;
        for (int j = 0; j < n; ++j) {
            i = (i + k) % n;
            prev = curr;
            curr = nums[i];
            nums[i] = prev;
            if (i == start) {
                ++start;
                curr = nums[start];
                i = start;
            }
        }
    }
}

