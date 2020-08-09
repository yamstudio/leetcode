/*
 * @lc app=leetcode id=1009 lang=csharp
 *
 * [1009] Complement of Base 10 Integer
 */

// @lc code=start
public class Solution {
    public int BitwiseComplement(int N) {
        if (N == 0) {
            return 1;
        }
        int l;
        for (l = 31; l >= 0 && (N & (1 << l)) == 0; --l);
        return N ^ ((1 << (l + 1)) - 1);
    }
}
// @lc code=end

