/*
 * @lc app=leetcode id=50 lang=csharp
 *
 * [50] Pow(x, n)
 */
public class Solution {
    public double MyPow(double x, int n) {
        if (n == 0) {
            return 1;
        }
        double half = MyPow(x, n / 2);
        if (n % 2 == 0) {
            return half * half;
        }
        if (n > 0) {
            return half * half * x;
        } else {
            return half * half / x;
        }
    }
}

