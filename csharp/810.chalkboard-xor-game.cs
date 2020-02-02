/*
 * @lc app=leetcode id=810 lang=csharp
 *
 * [810] Chalkboard XOR Game
 */

using System.Linq;

// @lc code=start
public class Solution {
    public bool XorGame(int[] nums) {
        return nums.Length % 2 == 0 || nums.Aggregate((acc, curr) => acc ^ curr) == 0;
    }
}
// @lc code=end

