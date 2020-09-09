/*
 * @lc app=leetcode id=1157 lang=csharp
 *
 * [1157] Online Majority Element In Subarray
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class MajorityChecker {

    private int[] Arr;
    private IDictionary<int, int[]> Indices;
    private Random Random;

    public MajorityChecker(int[] arr) {
        Arr = arr;
        Indices = arr
            .Select((int element, int index) => (Element: element, Index: index))
            .GroupBy(t => t.Element, (int element, IEnumerable<(int Element, int Index)> all) => (Element: element, Indices: all.Select(t => t.Index).ToArray()))
            .ToDictionary(t => t.Element, t => t.Indices);
        Random = new Random();
    }
    
    public int Query(int left, int right, int threshold) {
        var seen = new HashSet<int>(20);
        for (int i = 0; i < 20; ++i) {
            int val = Arr[Random.Next(left, right + 1)];
            var indices = Indices[val];
            int k = indices.Length;
            if (k < threshold || !seen.Add(val)) {
                continue;
            }
            int l = GetLower(indices, k, left), r = GetHigher(indices, k, right);
            if (r - l + 1 >= threshold) {
                return val;
            }
        }
        return -1;
    }

    private static int GetLower(int[] indices, int k, int lower) {
        int l = 0, r = k;
        while (l < r) {
            int m = (l + r) / 2;
            if (indices[m] < lower) {
                l = m + 1;
            } else {
                r = m;
            }
        }
        return l;
    }

    private static int GetHigher(int[] indices, int k, int higher) {
        int l = 0, r = k - 1;
        while (l + 1 < r) {
            int m = (l + r) / 2;
            if (indices[m] > higher) {
                r = m - 1;
            } else {
                l = m;
            }
        }
        while (r >= 0 && indices[r] > higher) {
            --r;
        }
        return r;
    }
}

/**
 * Your MajorityChecker object will be instantiated and called as such:
 * MajorityChecker obj = new MajorityChecker(arr);
 * int param_1 = obj.Query(left,right,threshold);
 */
// @lc code=end

