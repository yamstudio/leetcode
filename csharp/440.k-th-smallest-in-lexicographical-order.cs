/*
 * @lc app=leetcode id=440 lang=csharp
 *
 * [440] K-th Smallest in Lexicographical Order
 */
public class Solution {
    public int FindKthNumber(int n, int k) {
        int ret = 1;
        --k;
        while (k > 0) {
            long left = ret, right = ret + 1, diff = 0;
            while (left <= n) {
                diff += Math.Min((long) n + 1, right) - left;
                left *= 10;
                right *= 10;
            }
            if (diff <= k) {
                k -= (int) diff;
                ++ret;
            } else {
                --k;
                ret *= 10;
            }
        }
        return ret;
    }
}

