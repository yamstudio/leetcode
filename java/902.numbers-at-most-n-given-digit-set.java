/*
 * @lc app=leetcode id=902 lang=java
 *
 * [902] Numbers At Most N Given Digit Set
 */

// @lc code=start
class Solution {
    public int atMostNGivenDigitSet(String[] digits, int n) {
        String s = Integer.toString(n);
        int k = s.length(), ret = 0, m = digits.length;
        int[] pow = new int[k];
        pow[0] = 1;
        for (int i = 1; i < k; ++i) {
            pow[i] = m * pow[i - 1];
            ret += pow[i];
        }
        for (int i = 0; i < k; ++i) {
            char t = s.charAt(i);
            boolean flag = false;
            for (String d : digits) {
                char c = d.charAt(0);
                if (c < t) {
                    ret += pow[k - 1 - i];
                } else {
                    if (c == t) {
                        flag = true;
                    }
                    break;
                }
            }
            if (!flag) {
                return ret;
            }
        }
        return ret + 1;
    }
}
// @lc code=end

