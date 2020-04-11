/*
 * @lc app=leetcode id=866 lang=csharp
 *
 * [866] Prime Palindrome
 */

using System;

// @lc code=start
public class Solution {

    private static int[] Singles = new int[] {
        2, 2, 3, 5, 5, 7, 7, 11, 11, 11, 11
    };
    
    private static bool IsPrime(int x) {
        if (x <= 2) {
            return x == 2;
        }
        int m = (int)Math.Sqrt(x);
        for (int i = 2; i <= m; ++i) {
            if (x % i == 0) {
                return false;
            }
        }
        return true;
    }
    
    public int PrimePalindrome(int N) {
        if (N <= 11) {
            return Singles[N - 1];
        }

        for (int x = 10; true; ++x) {
            int t = x / 10, y = 0, c = 1;
            while (t > 0) {
                y = y * 10 + t % 10;
                t /= 10; 
                c *= 10;
            }
            y += c * x;
            if (y >= N && IsPrime(y)) {
                return y;
            }
        }
    }
}
// @lc code=end

