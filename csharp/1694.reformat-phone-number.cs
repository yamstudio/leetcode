/*
 * @lc app=leetcode id=1694 lang=csharp
 *
 * [1694] Reformat Phone Number
 */

using System.Linq;
using System.Text;

// @lc code=start
public class Solution {
    public string ReformatNumber(string number) {
        var nums = number
            .Where(c => c >= '0' && c <= '9')
            .ToArray();
        var sb = new StringBuilder();
        int n = nums.Length, b = n / 3, r = n % 3;
        if (r == 1) {
            --b;
        }
        for (int i = 0; i < b; ++i) {
            sb.Append(nums[i* 3]);
            sb.Append(nums[i* 3 + 1]);
            sb.Append(nums[i* 3 + 2]);
            sb.Append('-');
        }
        if (r == 0) {
            sb.Remove(sb.Length - 1, 1);
        } else if (r == 1) {
            sb.Append(nums[n - 4]);
            sb.Append(nums[n - 3]);
            sb.Append('-');
            sb.Append(nums[n - 2]);
            sb.Append(nums[n - 1]);
        } else {
            sb.Append(nums[n - 2]);
            sb.Append(nums[n - 1]);
        }
        return sb.ToString();
    }
}
// @lc code=end

