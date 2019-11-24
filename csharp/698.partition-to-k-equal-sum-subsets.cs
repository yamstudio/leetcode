/*
 * @lc app=leetcode id=698 lang=csharp
 *
 * [698] Partition to K Equal Sum Subsets
 */

using System.Linq;

// @lc code=start
public class Solution {

    private static bool CanPartitionKSubsetsRecurse(int[] nums, int n, int start, int k, int target, int curr, bool[] visited) {
        if (k == 1) {
            return true;
        }
        if (curr > target) {
            return false;
        }
        if (curr == target) {
            return CanPartitionKSubsetsRecurse(nums, n, 0, k - 1, target, 0, visited);
        }
        for (int i = start; i < n; ++i) {
            if (visited[i]) {
                continue;
            }
            visited[i] = true;
            if (CanPartitionKSubsetsRecurse(nums, n, i + 1, k, target, curr + nums[i], visited)) {
                return true;
            }
            visited[i] = false;
        }
        return false;
    }

    public bool CanPartitionKSubsets(int[] nums, int k) {
        int sum = nums.Sum(), n = nums.Length;
        if (sum % k != 0) {
            return false;
        }
        return CanPartitionKSubsetsRecurse(nums, n, 0, k, sum / k, 0, new bool[n]);
    }
}
// @lc code=end

