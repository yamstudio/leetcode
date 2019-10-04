/*
 * @lc app=leetcode id=486 lang=csharp
 *
 * [486] Predict the Winner
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static int PredictTheWinnerRecurse(IDictionary<(int, int), int> map, int[] nums, int start, int end, int n) {
        var key = (start, end);
        if (!map.ContainsKey(key)) {
            map[key] = (start == end) ? nums[start] : Math.Max(nums[start] - PredictTheWinnerRecurse(map, nums, start + 1, end, n), nums[end] - PredictTheWinnerRecurse(map, nums, start, end - 1, n));
        }
        return map[key];
    }

    public bool PredictTheWinner(int[] nums) {
        int n = nums.Length;
        return PredictTheWinnerRecurse(new Dictionary<(int, int), int>(), nums, 0, n - 1, n) >= 0;
    }
}
// @lc code=end

