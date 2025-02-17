/*
 * @lc app=leetcode id=1363 lang=java
 *
 * [1363] Largest Multiple of Three
 */

// @lc code=start
class Solution {
    public String largestMultipleOfThree(int[] digits) {
        int[] count = new int[10], needs = new int[3], max = new int[3];
        for (int d : digits) {
            ++count[d];
            ++needs[d % 3];
            max[d % 3] = Math.max(max[d % 3], d);
        }
        int q = (needs[1] + 2 * needs[2]) % 3;
        if (q == 1) {
            if (needs[1] > 0) {
                --needs[1];
            } else {
                needs[2] -= 2;
            }
        } else if (q == 2) {
            if (needs[2] > 0) {
                --needs[2];
            } else {
                needs[1] -= 2;
            }
        }
        if (needs[1] == 0 && needs[2] == 0) {
            if (needs[0] == 0) {
                return "";
            }
            if (max[0] == 0) {
                return "0";
            }
        }
        int length = needs[0] + needs[1] + needs[2];
        StringBuilder ret = new StringBuilder(length);
        while (length > 0) {
            int n = -1;
            for (int i = 0; i < 3; ++i) {
                if (needs[i] == 0) {
                    continue;
                }
                n = Math.max(n, max[i]);
            }
            ret.append(n);
            --needs[n % 3];
            --count[n];
            --length;
            while (n >= 0 && count[n] == 0) {
                n -= 3;
            }
            max[(n + 3) % 3] = n;
        }
        return ret.toString();
    }
}
// @lc code=end

