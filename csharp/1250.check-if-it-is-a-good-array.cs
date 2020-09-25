/*
 * @lc app=leetcode id=1250 lang=csharp
 *
 * [1250] Check If It Is a Good Array
 */

// @lc code=start
public class Solution {
    
    private static int GetGcdRecurse(int x, int y) {
        return y == 0 ? x : GetGcdRecurse(y, x % y);
    }
    
    public bool IsGoodArray(int[] nums) {
        int n = nums.Length, d = nums[0];
        for (int i = 1; i < n && d > 1; ++i) {
            d = GetGcdRecurse(d, nums[i]);
        }
        return d == 1;
    }
}
// @lc code=end

