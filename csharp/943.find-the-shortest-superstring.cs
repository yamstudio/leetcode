/*
 * @lc app=leetcode id=943 lang=csharp
 *
 * [943] Find the Shortest Superstring
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// @lc code=start
public class Solution {

    private static void ShortestSuperstringRecurse(string[] A, int[,] shared, int n, int len, IList<int> curr, int used, ref int minLen, ref int[] ret) {
        if (len >= minLen) {
            return;
        }
        if (n == curr.Count) {
            ret = curr.ToArray();
            minLen = len;
            return;
        }
        for (int i = 0; i < n; ++i) {
            if ((used & (1 << i)) != 0) {
                continue;
            }
            curr.Add(i);
            ShortestSuperstringRecurse(A, shared, n, curr.Count == 1 ? A[i].Length : len + A[i].Length - shared[curr[curr.Count - 2], i], curr, (used | (1 << i)), ref minLen, ref ret);
            curr.RemoveAt(curr.Count - 1);
        }
    }

    public string ShortestSuperstring(string[] A) {
        int n = A.Length, minLen = int.MaxValue;
        int[] ret = new int[n];
        int[,] shared = new int[n, n];
        for (int i = 0; i < n; ++i) {
            var s1 = A[i];
            for (int j = 0; j < n; ++j) {
                if (i == j) {
                    continue;
                }
                var s2 = A[j];
                for (int len = Math.Min(s1.Length, s2.Length); len > 0; --len) {
                    if (s1.Substring(s1.Length - len) == s2.Substring(0, len)) {
                        shared[i, j] = len;
                        break;
                    }
                }
            }
        }
        ShortestSuperstringRecurse(A, shared, n, 0, new List<int>(n), 0, ref minLen, ref ret);
        var sb = new StringBuilder();
        sb.Append(A[ret[0]]);
        for (int i = 0; i < n - 1; ++i) {
            int curr = ret[i], next = ret[i + 1];
            sb.Append(A[next].Substring(shared[curr, next]));
        }
        return sb.ToString();
    }
}
// @lc code=end

