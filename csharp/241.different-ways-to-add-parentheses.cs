/*
 * @lc app=leetcode id=241 lang=csharp
 *
 * [241] Different Ways to Add Parentheses
 */

using System;
using System.Collections.Generic;

public class Solution {

    private static readonly IDictionary<char, Func<int, int, int>> Ops = new Dictionary<char, Func<int, int, int>>
    {
        { '+', (x, y) => x + y },
        { '-', (x, y) => x - y },
        { '*', (x, y) => x * y },
    };
    private static readonly IList<int> Empty = Array.Empty<int>();

    private IList<int> DiffWaysToComputeRecurse(string input, int start, int end, IDictionary<(int, int), IList<int>> map) {
        var key = (start, end);
        if (map.ContainsKey(key)) {
            return map[key];
        }
        if (start > end) {
            return Empty;
        }
        var ret = new List<int>();
        for (int i = start; i <= end; ++i) {
            char c = input[i];
            if (c >= '0' && c <= '9') {
                continue;
            }
            var left = DiffWaysToComputeRecurse(input, start, i - 1, map);
            var right = DiffWaysToComputeRecurse(input, i + 1, end, map);
            foreach (int x in left) {
                foreach (int y in right) {
                    ret.Add(Ops[c].Invoke(x, y));
                }
            }
        }
        if (ret.Count == 0) {
            ret.Add(int.Parse(input.Substring(start, end - start + 1)));
        }
        map[key] = ret;
        return ret;
    }

    public IList<int> DiffWaysToCompute(string input) {
        return DiffWaysToComputeRecurse(input, 0, input.Length - 1, new Dictionary<(int, int), IList<int>>());
    }
}

