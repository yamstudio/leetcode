/*
 * @lc app=leetcode id=949 lang=csharp
 *
 * [949] Largest Time for Given Digits
 */

using System;

// @lc code=start
public class Solution {
    public string LargestTimeFromDigits(int[] A) {
        string ret = "";
        for (int i = 0; i < 4; ++i) {
            int d1 = A[i];
            if (d1 > 2) {
                continue;
            }
            for (int j = 0; j < 4; ++j) {
                if (i == j) {
                    continue;
                }
                int d2 = A[j];
                if (d1 == 2 && d2 > 3) {
                    continue;
                }
                for (int k = 0; k < 4; ++k) {
                    if (i == k || j == k) {
                        continue;
                    }
                    int d3 = A[k], d4 = A[6 - i - j - k];
                    if (d3 > 5) {
                        continue;
                    }
                    string curr = $"{d1}{d2}:{d3}{d4}";
                    if (curr.CompareTo(ret) > 0) {
                        ret = curr;
                    }
                }
            }
        }
        return ret;
    }
}
// @lc code=end

