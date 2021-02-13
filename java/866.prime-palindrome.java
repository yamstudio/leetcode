/*
 * @lc app=leetcode id=866 lang=java
 *
 * [866] Prime Palindrome
 */

// @lc code=start
class Solution {

    private static boolean isPrime(int N) {
        if (N <= 2) {
            return N == 2;
        }
        for (int i = (int)Math.sqrt(N); i >= 2; --i) {
            if (N % i == 0) {
                return false;
            }
        }
        return true;
    }

    public int primePalindrome(int N) {
        if (N >= 8 && N <= 11) {
            return 11;
        }
        for (int i = 0; i < 100000; ++i) {
            String s = Integer.toString(i);
            int x = Integer.parseInt(s.substring(0, s.length() - 1) + (new StringBuilder(s)).reverse().toString());
            if (x >= N && isPrime(x)) {
                return x;
            }
        }
        return -1;
    }
}
// @lc code=end

