/*
 * @lc app=leetcode id=1418 lang=java
 *
 * [1418] Display Table of Food Orders in a Restaurant
 */

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

// @lc code=start
class Solution {
    public List<List<String>> displayTable(List<List<String>> orders) {
        Set<String> foods = new HashSet<>();
        Map<String, Map<String, Integer>> tableToFoodToCount = new HashMap<>();
        for (var order : orders) {
            String table = order.get(1), food = order.get(2);
            foods.add(food);
            var map = tableToFoodToCount.computeIfAbsent(table, ignored -> new HashMap<>());
            map.put(food, map.getOrDefault(food, 0) + 1);
        }
        List<String> headers = new ArrayList<>(foods.size() + 1);
        headers.add("Table");
        foods.stream().sorted().forEach(headers::add);
        List<List<String>> ret = new ArrayList<>(tableToFoodToCount.size() + 1);
        ret.add(headers);
        tableToFoodToCount.entrySet().stream().sorted(java.util.Comparator.comparing((Map.Entry<String, Map<String, Integer>> entry) -> Integer.parseInt(entry.getKey()))).forEach(entry -> {
            int n = foods.size();
            List<String> row = new ArrayList<>(1 + n);
            row.add(entry.getKey());
            for (int i = 1; i <= n; ++i) {
                row.add(entry.getValue().getOrDefault(headers.get(i), 0).toString());
            }
            ret.add(row);
        });
        return ret;
    }
}
// @lc code=end

