/*
 * @lc app=leetcode id=13 lang=csharp
 *
 * [13] Roman to Integer
 */

using System.Collections.Generic;

public class Solution {
    public int RomanToInt(string s) {
        Dictionary<string, int> map = new Dictionary<string, int>();
        map["I"] = 1;
        map["IV"] = 4;
        map["V"] = 5;
        map["IX"] = 9;
        map["X"] = 10;
        map["XL"] = 40;
        map["L"] = 50;
        map["XC"] = 90;
        map["C"] = 100;
        map["CD"] = 400;
        map["D"] = 500;
        map["CM"] = 900;
        map["M"] = 1000;
        int ret = 0;
        for (int i = 0; i < s.Length; ++i) {
            if (i + 1 < s.Length) {
                string two = s.Substring(i, 2);
                if (map.ContainsKey(two)) {
                    ret += map[two];
                    ++i;
                    continue;
                }
            }
            ret += map[s.Substring(i, 1)];
        }
        return ret;
    }
}

