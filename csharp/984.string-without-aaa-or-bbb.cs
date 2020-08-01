/*
 * @lc app=leetcode id=984 lang=csharp
 *
 * [984] String Without AAA or BBB
 */

// @lc code=start
public class Solution {

    private static void SetChar(char[] ret, int i, ref int more, ref int less, ref int count, char mc, char lc, ref char p) {
        if (p == mc) {
            if (count < 2) {
                ++count;
                --more;
                ret[i] = mc;
            } else {
                count = 1;
                --less;
                p = lc;
                ret[i] = lc;
            }
        } else {
            count = 1;
            --more;
            p = mc;
            ret[i] = mc;
        }
    }

    public string StrWithout3a3b(int A, int B) {
        int n = A + B, c = 0;
        char p = '*';
        var ret = new char[n];
        for (int i = 0; i < n; ++i) {
            if (A >= B) {
                SetChar(ret, i, ref A, ref B, ref c, 'a', 'b', ref p);
            } else {
                SetChar(ret, i, ref B, ref A, ref c, 'b', 'a', ref p);
            }
        }
        return new string(ret);
    }
}
// @lc code=end

