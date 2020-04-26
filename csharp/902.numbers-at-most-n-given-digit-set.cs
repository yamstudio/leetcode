/*
 * @lc app=leetcode id=902 lang=csharp
 *
 * [902] Numbers At Most N Given Digit Set
 */

// @lc code=start
public class Solution {
    public int AtMostNGivenDigitSet(string[] D, int N) {
        string s = N.ToString();
        int len = s.Length, ret = 0, k = D.Length;
        int[] pow = new int[len];
        pow[0] = 1;
        for (int i = 1; i < len; ++i) {
            pow[i] = pow[i - 1] * k;
            ret += pow[i];
        }
        for (int i = 0; i < len; ++i) {
            char c = s[i];
            bool end = true;
            foreach (string d in D) {
                if (d[0] < c) {
                    ret += pow[len - i - 1];
                } else {
                    if (d[0] == c) {
                        end = false;
                    }
                    break;
                }
            }
            if (end) {
                return ret;
            }
        }
        return ret + 1;
    }
}
// @lc code=end

