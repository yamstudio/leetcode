/*
 * @lc app=leetcode id=481 lang=csharp
 *
 * [481] Magical String
 */

// @lc code=start
public class Solution {
    public int MagicalString(int n) {
        if (n == 0) {
            return 0;
        }
        if (n < 3) {
            return 1;
        }
        int[] str = new int[n + 1];
        int num = 1, i = 2, end = 3, ret = 1;
        str[0] = 1;
        str[1] = 2;
        str[2] = 2;
        while (end < n) {
            for (int j = str[i]; j > 0; --j) {
                if (num == 1 && end < n) {
                    ++ret;
                }
                str[end++] = num;
            }
            num ^= 3;
            ++i;
        }
        return ret;
    }
}
// @lc code=end

