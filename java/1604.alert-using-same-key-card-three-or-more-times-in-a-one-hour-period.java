/*
 * @lc app=leetcode id=1604 lang=java
 *
 * [1604] Alert Using Same Key-Card Three or More Times in a One Hour Period
 */

import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

// @lc code=start
class Solution {
    public List<String> alertNames(String[] keyName, String[] keyTime) {
        Map<String, List<Integer>> map = new HashMap<>();
        int n = keyName.length;
        for (int i = 0; i < n; ++i) {
            String name = keyName[i], time = keyTime[i];
            String[] split = time.split(":", -1);
            map.computeIfAbsent(name, ignored -> new ArrayList<>()).add(60 * Integer.parseInt(split[0]) + Integer.parseInt(split[1]));
        }
        List<String> ret = new ArrayList<>();
        for (var nameToTimes : map.entrySet()) {
            String name = nameToTimes.getKey();
            List<Integer> times = nameToTimes.getValue();
            Collections.sort(times);
            int k = times.size();
            int l = 0;
            for (int r = 0; r < k; ++r) {
                while (times.get(l) < times.get(r) - 60) {
                    ++l;
                }
                if (l <= r - 2) {
                    ret.add(name);
                    break;
                }
            }
        }
        Collections.sort(ret);
        return ret;
    }
}
// @lc code=end

