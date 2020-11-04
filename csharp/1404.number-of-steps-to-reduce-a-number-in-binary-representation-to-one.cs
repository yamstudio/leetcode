/*
 * @lc app=leetcode id=1404 lang=csharp
 *
 * [1404] Number of Steps to Reduce a Number in Binary Representation to One
 */

// @lc code=start
public class Solution {
    public int NumSteps(string s) {
        int ret = 0, n = s.Length;
        bool carry = false;
        for (int i = n - 1; i > 0; --i) {
            bool isOne = s[i] == '1';
            if (isOne ^ carry) {
                carry = true;
                ret += 2;
            } else {
                ret++;
            }
        }
        return carry ? ret + 1 : ret;
    }
}
// @lc code=end

