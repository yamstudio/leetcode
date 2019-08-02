/*
 * @lc app=leetcode id=166 lang=csharp
 *
 * [166] Fraction to Recurring Decimal
 */

using System.Text;
using System.Collections.Generic;

public class Solution {
    public string FractionToDecimal(int numerator, int denominator) {
        StringBuilder sb = new StringBuilder();
        if (numerator != 0 && (numerator < 0 ^ denominator < 0)) {
            sb.Append('-');
        }
        long n = Math.Abs((long) numerator), d = Math.Abs((long) denominator);
        sb.Append(n / d);
        n = n % d;
        if (n == 0) {
            return sb.ToString();
        }
        IDictionary<long, int> map = new Dictionary<long, int>();
        sb.Append('.');
        while (!map.ContainsKey(n)) {
            map[n] = sb.Length;
            n *= 10;
            sb.Append(n / d);
            n = n % d;
            if (n == 0) {
                return sb.ToString();
            }
        }
        sb.Insert(map[n], '(');
        sb.Append(')');
        return sb.ToString();
    }
}

