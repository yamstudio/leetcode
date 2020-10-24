/*
 * @lc app=leetcode id=1363 lang=csharp
 *
 * [1363] Largest Multiple of Three
 */

using System;
using System.Linq;
using System.Text;

// @lc code=start
public class Solution {
    public string LargestMultipleOfThree(int[] digits) {
        int[] count = new int[10], total = new int[3], p = new int[3];
        int n = digits.Length;
        foreach (int x in digits) {
            ++count[x];
            ++total[x % 3];
            p[x % 3] = Math.Max(p[x % 3], x);
        }
        int d = (total[1] + 2 * total[2]) % 3;
        if (d == 1) {
            if (total[1] > 0) {
                --total[1];
            } else {
                total[2] -= 2;
            }
        } else if (d == 2) {
            if (total[2] > 0) {
                --total[2];
            } else {
                total[1] -= 2;
            }
        }
        if (total[1] == 0 && total[2] == 0) {
            if (total[0] == 0) {
                return "";
            }
            if (p[0] == 0) {
                return "0";
            }
        }
        var ret = new StringBuilder(total.Sum());
        while (total.Any(c => c > 0)) {
            int m = Enumerable.Range(0, 3).Max(i => total[i] > 0 ? p[i] : -1), j = m % 3;
            ret.Append(m);
            --total[j];
            --count[m];
            while (m >= 0 && count[m] == 0) {
                m -= 3;
            }
            p[j] = m;
        }
        return ret.ToString();
    }
}
// @lc code=end

