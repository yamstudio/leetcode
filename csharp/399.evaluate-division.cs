/*
 * @lc app=leetcode id=399 lang=csharp
 *
 * [399] Evaluate Division
 */

using System.Collections.Generic;

public class Solution {

    private double CalcEquationRecurse(IDictionary<string, IDictionary<string, double>> map, ISet<string> visited, string num, string denom) {
        if (map[num].ContainsKey(denom)) {
            return map[num][denom];
        }
        foreach (var entry in map[num]) {
            string next = entry.Key;
            if (visited.Contains(next)) {
                continue;
            }
            visited.Add(next);
            double val = CalcEquationRecurse(map, visited, next, denom);
            if (val > 0) {
                return val * entry.Value;
            }
        }
        return -1.0;
    }

    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
        IDictionary<string, IDictionary<string, double>> map = new Dictionary<string, IDictionary<string, double>>();
        double[] ret = new double[queries.Count];
        for (int i = 0; i < equations.Count; ++i) {
            var equation = equations[i];
            double val = values[i];
            string num = equation[0], denom = equation[1];
            if (!map.ContainsKey(num)) {
                map[num] = new Dictionary<string, double>();
            }
            if (!map.ContainsKey(denom)) {
                map[denom] = new Dictionary<string, double>();
            }
            map[num][denom] = val;
            map[denom][num] = 1.0 / val;
        }
        for (int i = 0; i < queries.Count; ++i) {
            var query = queries[i];
            string num = query[0], denom = query[1];
            if (!map.ContainsKey(num) || !map.ContainsKey(denom)) {
                ret[i] = -1.0;
            } else {
                ret[i] = CalcEquationRecurse(map, new HashSet<string>(), num, denom);
            }
        }
        return ret;
    }
}

