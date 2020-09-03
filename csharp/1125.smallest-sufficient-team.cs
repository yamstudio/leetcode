/*
 * @lc app=leetcode id=1125 lang=csharp
 *
 * [1125] Smallest Sufficient Team
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int[] SmallestSufficientTeam(string[] req_skills, IList<IList<string>> people) {
        var skillMap = req_skills
            .Select((string skill, int index) => (Skill: skill, Index: index))
            .ToDictionary(t => t.Skill, t => t.Index);
        var ps = people
            .Select(p => p.Aggregate(0, (int acc, string curr) => (acc | (1 << skillMap[curr]))))
            .ToArray();
        int m = skillMap.Count, n = ps.Length, me = 1 << m;
        var states = new Dictionary<int, (int Count, int Addition, int Prev)>(me);
        states[0] = (Count: 0, Addition: -1, Prev: -1);
        for (int i = 0; i < n; ++i) {
            int p = ps[i];
            for (int j = 0; j < me; ++j) {
                if (!states.TryGetValue(j, out var t)) {
                    continue;
                }
                int newSkill = p | j;
                if (!states.TryGetValue(newSkill, out var nt) || nt.Count > t.Count + 1) {
                    states[newSkill] = (Count: t.Count + 1, Addition: i, Prev: j);
                }
            }
        }
        var s = states[me - 1];
        int[] ret = new int[s.Count];
        for (int i = s.Count - 1; i >= 0; --i) {
            ret[i] = s.Addition;
            s = states[s.Prev];
        }
        return ret;
    }
}
// @lc code=end

