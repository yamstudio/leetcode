/*
 * @lc app=leetcode id=231 lang=csharp
 *
 * [231] Power of Two
 */
public class Solution {
    public bool IsPowerOfTwo(int n) {
        return n > 0 && (n == 1 || (n % 2 == 0 && IsPowerOfTwo(n / 2)));
    }
}

