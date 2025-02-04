/*
 * @lc app=leetcode id=1317 lang=java
 *
 * [1317] Convert Integer to the Sum of Two No-Zero Integers
 */

// @lc code=start
class Solution {
    public int[] getNoZeroIntegers(int n) {
        int a = 0, b = 0, carry = 0, tens = 1;
        while (n > 0) {
            int d = (10 + n % 10 + carry) % 10;
            if (d == 0 && n >= 10) {
                a += 5 * tens;
                b += 5 * tens;
                carry = -1;
            } else if (d == 1 && n >= 10) {
                a += 5 * tens;
                b += 6 * tens;
                carry = -1;
            } else {
                int h = d / 2;
                a += h * tens;
                b += (d - h) * tens;
                carry = carry == -1 && d == 9 ? -1 : 0;
            }
            tens *= 10;
            n /= 10;
        }
        return new int[] { a, b };
    }
}
// @lc code=end

