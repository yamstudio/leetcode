/*
 * @lc app=leetcode id=565 lang=csharp
 *
 * [565] Array Nesting
 */

// @lc code=start
public class Solution {
    public int ArrayNesting(int[] nums) {
        int n = nums.Length, max = 0;
        bool[] visited = new bool[n];
        foreach (int num in nums) {
            int curr = 0, i = num;
            while (!visited[i]) {
                ++curr;
                visited[i] = true;
                i = nums[i];
            }
            if (curr > max) {
                max = curr;
            }
        }
        return max;
    }
}
// @lc code=end

