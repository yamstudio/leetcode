/*
 * @lc app=leetcode id=397 lang=csharp
 *
 * [397] Integer Replacement
 */
public class Solution {
    public int IntegerReplacement(int n) {
        long curr = (long) n;
        int ret = 0;
        while (curr > 1) {
            if (curr % 2 == 0) {
                curr /= 2;
            } else {
                if ((curr & 0b10) == 0 || curr == 3) {
                    --curr;
                } else {
                    ++curr;
                }
            }
            ++ret;
        }
        return ret;
    }
}

