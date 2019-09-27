/*
 * @lc app=leetcode id=461 lang=csharp
 *
 * [461] Hamming Distance
 */
public class Solution {
    public int HammingDistance(int x, int y) {
        int ret = 0;
        x ^= y;
        while (x != 0) {
            ret += (x & 1);
            x >>= 1;
        }
        return ret;
    }
}

