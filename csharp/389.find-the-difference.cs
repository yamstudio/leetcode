/*
 * @lc app=leetcode id=389 lang=csharp
 *
 * [389] Find the Difference
 */
public class Solution {

    private static long Sum(string s) {
        long ret = 0;
        foreach (char c in s) {
            ret += (long) c;
        }
        return ret;
    }

    public char FindTheDifference(string s, string t) {
        return (char) (Sum(t) - Sum(s));
    }
}

