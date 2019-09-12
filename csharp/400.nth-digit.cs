/*
 * @lc app=leetcode id=400 lang=csharp
 *
 * [400] Nth Digit
 */
public class Solution {
    public int FindNthDigit(int n) {
        long num = 1, m = n, len = 1, count = 9;
        while (m > len * count) {
            m -= len * count;
            ++len;
            count *= 10;
            num *= 10;
        }
        num += (m - 1) / len;
        m = len - 1 - ((m - 1) % len);
        while (m-- > 0) {
            num /= 10;
        }
        return (int) (num % 10);
    }
}

