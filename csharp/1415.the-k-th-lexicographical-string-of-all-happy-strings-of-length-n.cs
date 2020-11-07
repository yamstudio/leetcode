/*
 * @lc app=leetcode id=1415 lang=csharp
 *
 * [1415] The k-th Lexicographical String of All Happy Strings of Length n
 */

// @lc code=start
public class Solution {
    public string GetHappyString(int n, int k) {
        int total = 3;
        for (int i = 1; i < n; ++i) {
            total *= 2;
        }
        if (k > total) {
            return "";
        }
        total /= 3;
        char[] ret = new char[n];
        int pc = --k / total;
        ret[0] = (char)((int)'a' + pc);
        k %= total;
        total /= 2;
        for (int i = 1; i < n; ++i) {
            int c = k / total;
            if (c >= pc) {
                ++c;
            }
            ret[i] = (char)((int)'a' + c);
            pc = c;
            k %= total;
            total /= 2;
        }
        return new string(ret);
    }
}
// @lc code=end

