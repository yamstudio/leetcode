/*
 * @lc app=leetcode id=756 lang=csharp
 *
 * [756] Pyramid Transition Matrix
 */

using System.Collections.Generic;
using System.Text;

// @lc code=start
public class Solution {

    private static bool PyramidTransitionRecurse(string bottom, StringBuilder next, IDictionary<string, IList<char>> allowed) {
        int n = next.Length;
        if (n == 1 && bottom.Length == 2) {
            return true;
        }
        if (n + 1 == bottom.Length) {
            return PyramidTransitionRecurse(next.ToString(), new StringBuilder(), allowed);
        }
        if (allowed.TryGetValue(bottom.Substring(n, 2), out var list)) {
            foreach (var c in list) {
                next.Append(c);
                if (PyramidTransitionRecurse(bottom, next, allowed)) {
                    return true;
                }
                next.Remove(n, 1);
            }
        }
        return false;
    }

    public bool PyramidTransition(string bottom, IList<string> allowed) {
        var map = new Dictionary<string, IList<char>>();
        foreach (var tuple in allowed) {
            var key = tuple.Substring(0, 2);
            IList<char> list;
            if (!map.TryGetValue(key, out list)) {
                list = new List<char>();
                map[key] = list;
            }
            list.Add(tuple[2]);
        }
        return PyramidTransitionRecurse(bottom, new StringBuilder(), map);
    }
}
// @lc code=end

