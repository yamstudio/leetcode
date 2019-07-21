/*
 * @lc app=leetcode id=119 lang=csharp
 *
 * [119] Pascal's Triangle II
 */

using System.Collections.Generic;

public class Solution {
    public IList<int> GetRow(int rowIndex) {
        int[] ret = new int[rowIndex + 1];
        ret[0] = 1;
        for (int i = 1; i <= rowIndex; ++i) {
            for (int j = i; j >= 1; --j) {
                ret[j] += ret[j - 1];
            }
        }
        return new List<int>(ret);
    }
}

