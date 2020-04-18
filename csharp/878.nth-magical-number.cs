/*
 * @lc app=leetcode id=878 lang=csharp
 *
 * [878] Nth Magical Number
 */

// @lc code=start
public class Solution {

    private static int GreatestCommonDivisor(int a, int b) {
        if (b == 0) {
            return a;
        }
        return GreatestCommonDivisor(b, a % b);
    }

    public int NthMagicalNumber(int N, int A, int B) {
        int l = A * B / GreatestCommonDivisor(A, B), count = l / A + l / B - 1, i = N % count, left = 0, right = l - 1;
        while (left < right) {
            int mid = left + (right - left) / 2;
            if (mid / A + mid / B < i) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return (int)((((long)l * (long)(N / count)) % 1000000007 + (long)left) % 1000000007);
    }
}
// @lc code=end

