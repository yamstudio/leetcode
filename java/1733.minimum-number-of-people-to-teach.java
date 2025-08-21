/*
 * @lc app=leetcode id=1733 lang=java
 *
 * [1733] Minimum Number of People to Teach
 */

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

// @lc code=start

class Solution {
    public int minimumTeachings(int n, int[][] languages, int[][] friendships) {
        int k = languages.length;
        List<Set<Integer>> langs = new ArrayList<>(k);
        Set<Integer> needs = new HashSet<>();
        for (int[] ls : languages) {
            Set<Integer> lang = new HashSet<>(ls.length);
            for (int l : ls) {
                lang.add(l - 1);
            }
            langs.add(lang);
        }
        for (int[] p : friendships) {
            int a = p[0] - 1, b = p[1] - 1;
            Set<Integer> as = langs.get(a), bs = langs.get(b);
            boolean canSpeak = false;
            for (int l : as) {
                if (bs.contains(l)) {
                    canSpeak = true;
                    break;
                }
            }
            if (!canSpeak) {
                needs.add(a);
                needs.add(b);
            }
        }
        if (needs.isEmpty()) {
            return 0;
        }
        int[] count = new int[n];
        for (int p : needs) {
            for (int l : langs.get(p)) {
                ++count[l];
            }
        }
        int common = 0;
        for (int c : count) {
            common = Math.max(common, c);
        }
        return needs.size() - common;
    }
}
// @lc code=end

