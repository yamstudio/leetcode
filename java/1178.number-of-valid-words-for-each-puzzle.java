/*
 * @lc app=leetcode id=1178 lang=java
 *
 * [1178] Number of Valid Words for Each Puzzle
 */

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

// @lc code=start
class Solution {
    public List<Integer> findNumOfValidWords(String[] words, String[] puzzles) {
        Map<Integer, Integer> stateToCount = new HashMap<>();
        for (String w : words) {
            int n = w.length(), state = 0;
            for (int i = 0; i < n; ++i) {
                state |= 1 << (w.charAt(i) - 'a');
            }
            stateToCount.put(state, stateToCount.getOrDefault(state, 0) + 1);
        }
        List<Integer> ret = new ArrayList<>(puzzles.length);
        for (String puzzle : puzzles) {
            int count = 0, n = puzzle.length();
            for (int indices = (1 << n) - 1; indices >= 1; --indices) {
                if ((indices & 1) == 0) {
                    continue;
                }
                int state = 0;
                for (int i = 0; i < n; ++i) {
                    if (((1 << i) & indices) != 0) {
                        state |= 1 << (puzzle.charAt(i) - 'a');
                    }
                }
                count += stateToCount.getOrDefault(state, 0);
            }
            ret.add(count);
        }
        return ret;
    }
}
// @lc code=end

