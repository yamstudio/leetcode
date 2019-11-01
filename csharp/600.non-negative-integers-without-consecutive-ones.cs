/*
 * @lc app=leetcode id=600 lang=csharp
 *
 * [600] Non-negative Integers without Consecutive Ones
 */

// @lc code=start
public class Solution {
    public int FindIntegers(int num) {
        int len = 0, tmp = num;
        while (tmp != 0) {
            ++len;
            tmp >>= 1;
        }
        int[] count = new int[len + 1];
        count[0] = 1;
        count[1] = 1;
        for (int i = 2; i <= len; ++i) {
            count[i] = count[i - 1] + count[i - 2];
        }
        int ret = count[len] + count[len - 1];
        for (int i = len - 2; i >= 0; --i) {
            int curr = (1 << i) & num, prev = (1 << (i + 1)) & num;
            if (curr != 0 && prev != 0) {
                break;
            }
            if (curr == 0 && prev == 0) {
                ret -= count[i];
            }
        }
        return ret;
    }
}
// @lc code=end

