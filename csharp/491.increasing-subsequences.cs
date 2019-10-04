/*
 * @lc app=leetcode id=491 lang=csharp
 *
 * [491] Increasing Subsequences
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private void FindSubsequencesRecurse(int[] nums, IList<IList<int>> ret, IList<int> curr, int i) {
        if (curr.Count >= 2) {
            ret.Add(new List<int>(curr));
        }
        ISet<int> visited = new HashSet<int>();
        for (int j = i; j < nums.Length; ++j) {
            int num = nums[j];
            if (visited.Contains(num) || (curr.Count > 0 && num < curr[curr.Count - 1])) {
                continue;
            }
            visited.Add(num);
            curr.Add(num);
            FindSubsequencesRecurse(nums, ret, curr, j + 1);
            curr.RemoveAt(curr.Count - 1);
        }
    }

    public IList<IList<int>> FindSubsequences(int[] nums) {
        var ret = new List<IList<int>>();
        FindSubsequencesRecurse(nums, ret, new List<int>(), 0);
        return ret;
    }
}
// @lc code=end

