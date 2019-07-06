/*
 * @lc app=leetcode id=43 lang=csharp
 *
 * [43] Multiply Strings
 */

using System.Text;

public class Solution {
    public string Multiply(string num1, string num2) {
        int[] ret = new int[num1.Length + num2.Length];
        for (int i = num1.Length - 1; i >= 0; --i) {
            for (int j = num2.Length - 1; j >= 0; --j) {
                int prod = ((int) (num1[i] - '0')) * ((int) (num2[j] - '0'));
                prod += ret[i + j + 1];
                ret[i + j] += prod / 10;
                ret[i + j + 1] = prod % 10;
            }
        }
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < ret.Length; ++i) {
            if (sb.Length > 0 || ret[i] != 0) {
                sb.Append(ret[i]);
            }
        }
        return sb.Length > 0 ? sb.ToString() : "0";
    }
}

