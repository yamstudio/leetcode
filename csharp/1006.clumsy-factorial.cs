/*
 * @lc app=leetcode id=1006 lang=csharp
 *
 * [1006] Clumsy Factorial
 */

// @lc code=start
public class Solution {
    public int Clumsy(int N) {
        int ret = 0, acc = 0;
        for (int i = N; i > 0; --i) {
            int x = (N - i) % 4;
            if (x == 0) {
                if (i == N) {
                    acc = i;
                } else {
                    acc = -i;
                }
            } else if (x == 1) {
                acc *= i;
            } else if (x == 2) {
                ret += acc / i;
                acc = 0;
            } else {
                ret += i;
            }
        }
        return ret + acc;
    }
}
// @lc code=end

