/*
 * @lc app=leetcode id=1655 lang=csharp
 *
 * [1655] Distribute Repeating Integers
 */

using System.Linq;

// @lc code=start
public class Solution {

    private static bool CanDistribute(int[] counts, int[] quantity, int i) {
        if (i == quantity.Length) {
            return true;
        }
        for (int j = 0; j < counts.Length; ++j) {
            if (counts[j] >= quantity[i]) {
                counts[j] -= quantity[i];
                if (CanDistribute(counts, quantity, i + 1)) {
                    return true;
                }
                counts[j] += quantity[i];
            }
        }
        return false;
    }

    public bool CanDistribute(int[] nums, int[] quantity) {
        return CanDistribute(nums.GroupBy(x => x, (x, a) => a.Count()).OrderByDescending(c => c).ToArray(), quantity.OrderByDescending(q => q).ToArray(), 0);
    }
}
// @lc code=end

