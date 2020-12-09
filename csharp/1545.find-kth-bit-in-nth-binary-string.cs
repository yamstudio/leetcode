/*
 * @lc app=leetcode id=1545 lang=csharp
 *
 * [1545] Find Kth Bit in Nth Binary String
 */

// @lc code=start
public class Solution {

    private static bool IsZero(int k, int len) {
        if (len == 1) {
            return true;
        }
        if (k == len / 2) {
            return false;
        }
        if (k < len / 2) {
            return IsZero(k, len / 2);
        }
        return !IsZero(len - k - 1, len / 2);
    }

    public char FindKthBit(int n, int k) {
        int len = 1;
        while (len < k) {
            len = len * 2 + 1;
        }
        return IsZero(k - 1, len) ? '0' : '1';
    }
}
// @lc code=end

