/*
 * @lc app=leetcode id=168 lang=csharp
 *
 * [168] Excel Sheet Column Title
 */

using System.Text;

public class Solution {
    public string ConvertToTitle(int n) {
        StringBuilder sb = new StringBuilder();
        --n;
        while (n >= 0) {
            sb.Insert(0, (char) (n % 26 + (int) 'A'));
            n = n / 26 - 1;
        };
        return sb.ToString();
    }
}

