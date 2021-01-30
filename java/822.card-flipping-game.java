/*
 * @lc app=leetcode id=822 lang=java
 *
 * [822] Card Flipping Game
 */

// @lc code=start
class Solution {
    public int flipgame(int[] fronts, int[] backs) {
        Set<Integer> all = new HashSet<Integer>();
        int n = fronts.length;
        for (int i = 0; i < n; ++i) {
            all.add(fronts[i]);
            all.add(backs[i]);
        }
        for (int i = 0; i < n; ++i) {
            if (fronts[i] == backs[i]) {
                all.remove(fronts[i]);
            }
        }
        if (all.size() == 0) {
            return 0;
        }
        return all.stream().min(Integer::compare).get();
    }
}
// @lc code=end

