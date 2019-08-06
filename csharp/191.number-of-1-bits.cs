/*
 * @lc app=leetcode id=191 lang=csharp
 *
 * [191] Number of 1 Bits
 */

using System.Linq;

public class Solution {
    public int HammingWeight(uint n) {
        return Enumerable.Range(0, 32).Aggregate((int) 0, (ret, i) => ret + (int) ((n >> i) & 1));
    }
}

