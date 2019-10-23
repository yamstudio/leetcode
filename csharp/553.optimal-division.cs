/*
 * @lc app=leetcode id=553 lang=csharp
 *
 * [553] Optimal Division
 */

using System.Linq;

// @lc code=start
public class Solution {
    public string OptimalDivision(int[] nums) {
        int n = nums.Length;
        if (n == 0) {
            return "";
        }
        if (n == 1) {
            return nums[0].ToString();
        }
        if (n == 2) {
            return $"{nums[0]}/{nums[1]}";
        }
        var div = string.Join("/", nums.Skip(1).Select(x => x.ToString()));
        return $"{nums[0]}/({div})";
    }
}
// @lc code=end

