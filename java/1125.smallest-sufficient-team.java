/*
 * @lc app=leetcode id=1125 lang=java
 *
 * [1125] Smallest Sufficient Team
 */

import java.util.HashMap;
import java.util.List;
import java.util.Map;

// @lc code=start
class Solution {
    public int[] smallestSufficientTeam(String[] reqSkills, List<List<String>> people) {
        Map<String, Integer> skillToIndex = new HashMap<>();
        int skillLen = reqSkills.length, target = (1 << skillLen) -1;
        for (int i = 0; i < skillLen; ++i) {
            skillToIndex.put(reqSkills[i], i);
        }
        Map<Integer, State> skillsToState = new HashMap<>();
        skillsToState.put(0, new State(0, -1, 0));
        int m = people.size();
        for (int i = 0; i < m; ++i) {
            int skills = 0;
            for (String skill : people.get(i)) {
                skills |= (1 << skillToIndex.get(skill));
            }
            for (int prevSkills = 0; prevSkills < target; ++prevSkills) {
                State prevState = skillsToState.get(prevSkills);
                if (prevState == null) {
                    continue;
                }
                int nextSkills = prevSkills | skills;
                State existingNextState = skillsToState.get(nextSkills);
                if (existingNextState == null || existingNextState.count() > prevState.count() + 1) {
                    skillsToState.put(nextSkills, new State(prevSkills, i, prevState.count() + 1));
                }
            }
        }
        State state = skillsToState.get(target);
        int[] ret = new int[state.count()];
        for (int i = state.count() - 1; i >= 0; --i) {
            ret[i] = state.index();
            state = skillsToState.get(state.prevSkills());
        }
        return ret;
    }

    private record State(int prevSkills, int index, int count) {}
}
// @lc code=end

