/*
 * @lc app=leetcode id=363 lang=csharp
 *
 * [363] Max Sum of Rectangle No Larger Than K
 */

using System.Collections.Generic;

public class Solution {
    public int MaxSumSubmatrix(int[][] matrix, int k) {
        int m = matrix.Length, n, ret = int.MinValue;
        if (m == 0) {
            return 0;
        }
        n = matrix[0].Length;
        SortedList<int, int> sorted = new SortedList<int, int>();
        for (int j = 0; j < n; ++j) {
            int[] sums = new int[m];
            for (int v = j; v < n; ++v) {
                for (int i = 0; i < m; ++i) {
                    sums[i] += matrix[i][v];
                }
                int curr = 0;
                sorted.Add(0, 0);
                foreach (int sum in sums) {
                    curr += sum;
                    int bound = curr - k;
                    var keys = sorted.Keys;
                    int left = 0, right = keys.Count;
                    while (left < right) {
                        int mid = left + (right - left) / 2;
                        if (keys[mid] >= bound) {
                            right = mid;
                        } else {
                            left = mid + 1;
                        }
                    }
                    if (left < sorted.Count) {
                        ret = Math.Max(ret, curr - keys[left]);
                    }
                    sorted[curr] = 0;
                }
                sorted.Clear();
            }
        }
        return ret;
    }
}

