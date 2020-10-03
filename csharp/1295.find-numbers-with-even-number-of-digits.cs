/*
 * @lc app=leetcode id=1295 lang=csharp
 *
 * [1295] Find Numbers with Even Number of Digits
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int FindNumbers(int[] nums) {
        return nums
            .Count((int num) => {
                bool ret = true;
                while (num > 0) {
                    ret = !ret;
                    num /= 10;
                }
                return ret;
            });
    }
}
// @lc code=end

