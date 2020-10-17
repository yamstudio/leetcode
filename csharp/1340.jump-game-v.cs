/*
 * @lc app=leetcode id=1340 lang=csharp
 *
 * [1340] Jump Game V
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static int GetMax(IDictionary<int, IList<int>> edges, int curr, int[] memo) {
        if (memo[curr] != 0) {
            return memo[curr];
        }
        if (!edges.TryGetValue(curr, out var l)) {
            return memo[curr] = 1;
        }
        int n = 0;
        foreach (int next in l) {
            n = Math.Max(n, GetMax(edges, next, memo));
        }
        return memo[curr] = 1 + n;
    }

    public int MaxJumps(int[] arr, int d) {
        var stack = new Stack<int>();
        int n = arr.Length;
        var edges = new Dictionary<int, IList<int>>();
        for (int i = 0; i < n; ++i) {
            int curr = arr[i];
            while (stack.TryPeek(out int j) && arr[j] < curr) {
                stack.Pop();
                if (i - j <= d) {
                    if (edges.TryGetValue(j, out var l)) {
                        l.Append(i);
                    } else {
                        edges[j] = new List<int>() { i };
                    }
                }
            }
            stack.Push(i);
        }
        for (int i = n - 1; i >= 0; --i) {
            int curr = arr[i];
            while (stack.TryPeek(out int j) && arr[j] < curr) {
                stack.Pop();
                if (j - i <= d) {
                    if (edges.TryGetValue(j, out var l)) {
                        l.Add(i);
                    } else {
                        edges[j] = new List<int>() { i };
                    }
                }
            }
            stack.Push(i);
        }
        int ret = 0;
        int[] memo = new int[n];
        for (int i = 0; i < n; ++i) {
            ret = Math.Max(ret, GetMax(edges, i, memo));
        }
        return ret;
    }
}
// @lc code=end

