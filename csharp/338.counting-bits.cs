/*
 * @lc app=leetcode id=338 lang=csharp
 *
 * [338] Counting Bits
 */
public class Solution {
    public int[] CountBits(int num) {
        int[] ret = new int[num + 1];
        for (int i = 1; i <= num; ++i) {
            ret[i] = ret[i / 2] + i % 2;
        }
        return ret;
    }
}

