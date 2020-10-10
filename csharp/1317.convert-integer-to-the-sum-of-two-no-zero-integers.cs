/*
 * @lc app=leetcode id=1317 lang=csharp
 *
 * [1317] Convert Integer to the Sum of Two No-Zero Integers
 */

// @lc code=start
public class Solution {
    public int[] GetNoZeroIntegers(int n) {
        int a = 0, b = 0, t = 1;
        bool carry = false;
        while (n > 0) {
            int k = n % 10;
            if (carry) {
                --k;
            }
            if (k < 2) {
                if (n < 10) {
                    if (k == 1) {
                        a += t;
                    }
                    break;
                }
                k += 10;
            }
            int l = k / 2, r = k - l;
            a += l * t;
            b += r * t;
            t *= 10;
            carry = k >= 10 || carry && k >= 9;
            n /= 10;
        }
        return new int[] { a, b };
    }
}
// @lc code=end

