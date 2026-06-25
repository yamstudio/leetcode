/*
 * @lc app=leetcode id=1773 lang=java
 *
 * [1773] Count Items Matching a Rule
 */

import java.util.List;
import java.util.Map;

// @lc code=start
class Solution {
    
    private static final Map<String, Integer> KEY_TO_INDEX = Map.of(
        "type", 0,
        "color", 1,
        "name", 2
    );
    
    public int countMatches(List<List<String>> items, String ruleKey, String ruleValue) {
        int i = KEY_TO_INDEX.get(ruleKey);
        return (int) items
            .stream()
            .filter(item -> item.get(i).equals(ruleValue))
            .count();
    }
}
// @lc code=end

