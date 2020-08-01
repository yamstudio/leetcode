/*
 * @lc app=leetcode id=982 lang=csharp
 *
 * [982] Triples with Bitwise AND Equal To Zero
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int CountTriplets(int[] A) {
        var count = new Dictionary<int, int>();
        int n = A.Length, ret = 0;
        for (int i = 0; i < n; ++i) {
            int a = A[i];
            for (int j = 0; j < n; ++j) {
                int s = a & A[j];
                if (count.TryGetValue(s, out int c)) {
                    count[s] = c + 1;
                } else {
                    count[s] = 1;
                }
            }
        }
        foreach (int b in A) {
            foreach (var tuple in count) {
                if ((tuple.Key & b) == 0) {
                    ret += tuple.Value;
                }
            }
        }
        return ret;
    }
}
// @lc code=end

