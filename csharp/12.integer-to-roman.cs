/*
 * @lc app=leetcode id=12 lang=csharp
 *
 * [12] Integer to Roman
 */

using System.Text;

public class Solution {
    public string IntToRoman(int num) {
        StringBuilder sb = new StringBuilder();
        int[] keys = new int[] {1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1};
        string[] vals = new string[] {"M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"};
        for (int i = 0; i < keys.Length; ++i) {
            int key = keys[i];
            string val = vals[i];
            while (num >= key) {
                num -= key;
                sb.Append(val);
            }
        }
        return sb.ToString();
    }
}

