/*
 * @lc app=leetcode id=1311 lang=java
 *
 * [1311] Get Watched Videos by Your Friends
 */

import java.util.ArrayDeque;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Queue;
import java.util.Set;

// @lc code=start

import static java.util.Comparator.comparing;

class Solution {
    public List<String> watchedVideosByFriends(List<List<String>> watchedVideos, int[][] friends, int id, int level) {
        Set<Integer> visited = new HashSet<>();
        Queue<Integer> queue = new ArrayDeque<>();
        visited.add(id);
        queue.offer(id);
        while (level-- > 0) {
            for (int i = queue.size(); i > 0; --i) {
                int curr = queue.poll();
                for (int f : friends[curr]) {
                    if (visited.add(f)) {
                        queue.offer(f);
                    }
                }
            }
        }
        Map<String, Integer> ret = new HashMap<>();
        while (!queue.isEmpty()) {
            int curr = queue.poll();
            for (String v : watchedVideos.get(curr)) {
                ret.put(v, 1 + ret.getOrDefault(v, 0));
            }
        }
        return ret
            .keySet()
            .stream()
            .sorted(comparing((String v) -> ret.get(v)).thenComparing((String v) -> v))
            .toList();
    }
}
// @lc code=end

