/*
 * @lc app=leetcode id=1366 lang=java
 *
 * [1366] Rank Teams by Votes
 */

import java.util.Comparator;
import java.util.HashMap;
import java.util.Map;

// @lc code=start
class Solution {
    public String rankTeams(String[] votes) {
        int k = votes[0].length();
        Map<Character, int[]> rankings = new HashMap<>(k);
        for (String vote : votes) {
            for (int i = 0; i < k; ++i) {
                char c = vote.charAt(i);
                rankings.computeIfAbsent(c, ignored -> new int[k])[i]++;
            }
        }
        StringBuilder sb = new StringBuilder(k);
        rankings
            .keySet()
            .stream()
            .sorted(new Comparator<Character>() {
                @Override
                public int compare(Character c1, Character c2) {
                    int[] r1 = rankings.get(c1), r2 = rankings.get(c2);
                    for (int i = 0; i < k; ++i) {
                        if (r1[i] != r2[i]) {
                            return r2[i] - r1[i];
                        }
                    }
                    return (int)c1 - (int)c2;
                }
            })
            .forEach(sb::append);
        return sb.toString();
    }
}
// @lc code=end

