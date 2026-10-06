/*
 * @lc app=leetcode id=1830 lang=java
 *
 * [1830] Minimum Number of Operations to Make String Sorted
 */

// @lc code=start
class Solution {
    
    private final int[] factorial;
    private final int[] inverseModulo;

    public Solution() {
        factorial = new int[3001];
        inverseModulo = new int[3001];
        factorial[0] = 1;
        inverseModulo[0] = 1;
        for (int i = 1; i <= 3000; ++i) {
            factorial[i] = (int)(((long)factorial[i - 1] * (long)i) % 1000000007);
            inverseModulo[i] = inverseModulo(factorial[i], 1000000005);
        }
    }

    public int makeStringSorted(String s) {
        int[] count = new int[26];
        int n = s.length();
        long ret = 0;
        for (int i = n - 1; i >= 0; --i) {
            int c = s.charAt(i) - 'a';
            long acc = 0;
            ++count[c];
            for (int p = 0; p < c; ++p) {
                acc += count[p];
            }
            acc = (acc * factorial[n - i - 1]) % 1000000007;
            for (int x : count) {
                acc = (acc * inverseModulo[x]) % 1000000007;
            }
            ret = (ret + acc) % 1000000007;
        }
        return (int)ret;
    }

    private static int inverseModulo(int x, int p) {
        if (p == 0) {
            return 1;
        }
        long r = inverseModulo(x, p / 2) % 1000000007, rr = (r * r) % 1000000007;
        if (p % 2 == 0) {
            return (int)rr;
        }
        return (int)((rr * (int)x) % 1000000007); 
    }
}
// @lc code=end

