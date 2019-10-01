/*
 * @lc app=leetcode id=476 lang=csharp
 *
 * [476] Number Complement
 */

// @lc code=start
public class Solution {
    public int FindComplement(int num) {
        int tmp = num, mask = 1;
        while (tmp != 0) {
            tmp >>= 1;
            mask <<= 1;
        }
        return num ^ (mask - 1);
    }
}
// @lc code=end

