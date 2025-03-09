/*
 * @lc app=leetcode id=1436 lang=java
 *
 * [1436] Destination City
 */

import java.util.HashSet;
import java.util.List;
import java.util.Set;

// @lc code=start
class Solution {
    public String destCity(List<List<String>> paths) {
        Set<String> end = new HashSet<>(paths.size());
        for (var p : paths) {
            end.add(p.get(1));
            end.remove(p.get(0));
        }
        for (var p : paths) {
            end.remove(p.get(0));
        }
        return end.stream().findFirst().orElseThrow();
    }
}
// @lc code=end

