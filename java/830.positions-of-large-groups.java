/*
 * @lc app=leetcode id=830 lang=java
 *
 * [830] Positions of Large Groups
 */

// @lc code=start
class Solution {
    public List<List<Integer>> largeGroupPositions(String s) {
        List<List<Integer>> ret = new ArrayList<List<Integer>>();
        int n = s.length();
        for (int i = 0; i < n;) {
            int ni = i + 1;
            while (ni < n && s.charAt(i) == s.charAt(ni)) {
                ++ni;
            }
            if (ni - i >= 3) {
                List<Integer> interval = new ArrayList<Integer>(2);
                interval.add(i);
                interval.add(ni - 1);
                ret.add(interval);
            }
            i = ni;
        }
        return ret;
    }
}
// @lc code=end

