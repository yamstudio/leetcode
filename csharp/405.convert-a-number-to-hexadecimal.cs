/*
 * @lc app=leetcode id=405 lang=csharp
 *
 * [405] Convert a Number to Hexadecimal
 */

using System.Collections.Generic;
using System.Linq;

public class Solution {
    public string ToHex(int num) {
        LinkedList<char> ret = new LinkedList<char>();
        for (int i = 0; i < 8 && num != 0; ++i) {
            int r = num & 0b1111;
            ret.AddFirst((char) (r < 10 ? (r + (int) '0') : (r + (int) 'a' - 10)));
            num >>= 4;
        }
        return ret.Count > 0 ? new string(ret.ToArray()) : "0";
    }
}

