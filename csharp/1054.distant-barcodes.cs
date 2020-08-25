/*
 * @lc app=leetcode id=1054 lang=csharp
 *
 * [1054] Distant Barcodes
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int[] RearrangeBarcodes(int[] barcodes) {
        int n = barcodes.Length, f = 0;
        int[] ret = new int[n];
        foreach (var barcode in barcodes
            .GroupBy(b => b, (int b, IEnumerable<int> all) => all.ToArray())
            .OrderByDescending(t => t.Length)
            .SelectMany(t => t)) {
            ret[f] = barcode;
            f += 2;
            if (f >= n) {
                f = 1;
            }
        }
        return ret;
    }
}
// @lc code=end

