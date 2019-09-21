/*
 * @lc app=leetcode id=441 lang=csharp
 *
 * [441] Arranging Coins
 */
public class Solution {
    public int ArrangeCoins(int n) {
        if (n <= 1) {
            return n;
        }
        long left = 1, right = (long) n;
        while (left < right) {
            long mid = left + (right - left) / 2;
            if (mid * (1 + mid) / 2 > n) {
                right = mid;
            } else {
                left = mid + 1;
            }
        }
        return (int) left - 1;
    }
}

