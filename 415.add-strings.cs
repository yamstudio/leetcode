/*
 * @lc app=leetcode id=415 lang=csharp
 *
 * [415] Add Strings
 */

using System.Collections.Generic;
using System.Linq;

public class Solution {
    public string AddStrings(string num1, string num2) {
        if (num1.Length < num2.Length) {
            string tmp = num1;
            num1 = num2;
            num2 = tmp;
        }
        LinkedList<char> ret = new LinkedList<char>();
        int n1 = num1.Length, n2 = num2.Length, carry = 0, i;
        for (i = 1; i <= n2; ++i) {
            int curr = (int) num1[n1 - i] + (int) num2[n2 - i] + carry - 2 * (int) '0';
            if (curr >= 10) {
                curr -= 10;
                carry = 1;
            } else {
                carry = 0;
            }
            ret.AddFirst((char) (curr + (int) '0'));
        }
        for (; i <= n1; ++i) {
            int curr = (int) num1[n1 - i] + carry - (int) '0';
            if (curr >= 10) {
                curr -= 10;
                carry = 1;
            } else {
                carry = 0;
            }
            ret.AddFirst((char) (curr + (int) '0'));
        }
        if (carry == 1) {
            ret.AddFirst('1');
        }
        return new string(ret.ToArray());
    }
}

