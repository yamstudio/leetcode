/*
 * @lc app=leetcode id=969 lang=csharp
 *
 * [969] Pancake Sorting
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static void Sort(int[] A, int end) {
        for (int i = 0; i < end; ++i, --end) {
            int tmp = A[i];
            A[i] = A[end];
            A[end] = tmp;
        }
    }

    public IList<int> PancakeSort(int[] A) {
        int n = A.Length;
        var ret = new List<int>();
        for (int i = 0; i < n; ++i) {
            int r = n - 1 - i, mi = 0, m = A[0];
            for (int j = 1; j <= r; ++j) {
                if (A[j] > m) {
                    mi = j;
                    m = A[j];
                }
            }
            Sort(A, mi);
            Sort(A, r);
            ret.Add(mi + 1);
            ret.Add(r + 1);
        }
        return ret;
    }
}
// @lc code=end

