/*
 * @lc app=leetcode id=1702 lang=csharp
 *
 * [1702] Maximum Binary String After Change
 */

using System.Linq;

// @lc code=start
public class Solution {
    public string MaximumBinaryString(string binary) {
        int n = binary.Length, leadingOnes = 0, zeros = 0;
        char[] ret = Enumerable.Repeat('1', n).ToArray();
        foreach (char c in binary) {
            if (c == '0') {
                ++zeros;
            } else if (zeros == 0) {
                ++leadingOnes;
            }
        }
        if (zeros > 0) {
            ret[leadingOnes + zeros - 1] = '0';
        }
        return new string(ret);
    }
}
// @lc code=end

