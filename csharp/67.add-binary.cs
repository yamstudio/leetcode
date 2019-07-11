/*
 * @lc app=leetcode id=67 lang=csharp
 *
 * [67] Add Binary
 */

using System.Text;

public class Solution {
    public string AddBinary(string a, string b) {
        StringBuilder sb = new StringBuilder();
        int n = Math.Min(a.Length, b.Length), carry = 0;
        for (int i = 0; i < n; ++i) {
            int sum = (int) (a[a.Length - 1 - i] - '0') + (int) (b[b.Length - 1 - i] - '0') + carry;
            carry = sum / 2;
            sum %= 2;
            sb.Insert(0, sum);
        }

        string s = a.Length > b.Length ? a : b;
        for (int i = n; i < s.Length; ++i) {
            int sum = (int) (s[s.Length - 1 - i] - '0') + carry;
            carry = sum / 2;
            sum %= 2;
            sb.Insert(0, sum);
        }
        if (carry > 0) {
            sb.Insert(0, 1);
        }
        return sb.ToString();
    }
}

