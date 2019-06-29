/*
 * @lc app=leetcode id=8 lang=csharp
 *
 * [8] String to Integer (atoi)
 */
public class Solution {
    public int MyAtoi(string str) {
        long ret = 0;
        bool neg = false, start = false;
        for (int i = 0; i < str.Length; ++i) {
            char c = str[i];
            if (!start) {
                if (c == ' ') {
                    continue;
                } else {
                    start = true;
                    if (c == '+') {
                        continue;
                    } else if (c == '-') {
                        neg = true;
                        continue;
                    }
                }
            }
            int val = (int) (c - '0');
            if (val < 0 || val > 9) {
                break;
            }
            ret = ret * 10 + val;
            if (!neg && ret > Int32.MaxValue) {
                return Int32.MaxValue;
            }
            if (neg && -ret < Int32.MinValue) {
                return Int32.MinValue;
            }
        }
        if (neg) {
            ret = -ret;
        }
        return (int) ret;
    }
}

