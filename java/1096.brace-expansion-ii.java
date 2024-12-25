/*
 * @lc app=leetcode id=1096 lang=java
 *
 * [1096] Brace Expansion II
 */

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

// @lc code=start
class Solution {
    public List<String> braceExpansionII(String expression) {
        return helper("{%s}".formatted(expression), 0).results().stream().sorted().toList();
    }

    private Result helper(String expression, int index) {
        int n = expression.length(), i = index;
        if (expression.charAt(i) != '{') {
            while (i < n && expression.charAt(i) != ',' && expression.charAt(i) != '}'&& expression.charAt(i) != '{') {
                ++i;
            }
            return new Result(Set.of(expression.substring(index, i)), i);
        }
        ++i;
        Set<String> ret = new HashSet<>();
        while (i < n && expression.charAt(i) != '}') {
            List<Set<String>> sections = new ArrayList<>();
            while (i < n && expression.charAt(i) != '}' && expression.charAt(i) != ',') {
                Result sectionResult = helper(expression, i);
                sections.add(sectionResult.results());
                i = sectionResult.nextIndex();
            }
            combine(new StringBuilder(), ret, sections, 0);
            if (i < n && expression.charAt(i) == ',') {
                ++i;
            }
        }
        return new Result(ret, i + 1);
    }

    private static void combine(StringBuilder sb, Set<String> results, List<Set<String>> sections, int i) {
        if (i == sections.size()) {
            results.add(sb.toString());
            return;
        }
        for (String s : sections.get(i)) {
            sb.append(s);
            combine(sb, results, sections, i + 1);
            sb.delete(sb.length() - s.length(), sb.length());
        }
    }

    private record Result(Set<String> results, int nextIndex) {}
}
// @lc code=end

