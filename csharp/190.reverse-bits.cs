/*
 * @lc app=leetcode id=190 lang=csharp
 *
 * [190] Reverse Bits
 */

using System.Linq;

public class Solution {
    public uint reverseBits(uint n) {
        return Enumerable.Range(0, 32).Aggregate((uint) 0, (ret, i) => ret | ((n >> i) & 1) << (31 - i));
    }
}

