/*
 * @lc app=leetcode id=1833 lang=java
 *
 * [1833] Maximum Ice Cream Bars
 */

// @lc code=start
class Solution {
    public int maxIceCream(int[] costs, int coins) {
        int ret = 0, l = Math.min(100000, coins);
        int[] count = new int[l + 1];
        for (int cost : costs) {
            if (cost > l) {
                continue;
            }
            ++count[cost];
        }
        for (int cost = 1; cost <= l && cost <= coins; ++cost) {
            int take = Math.min(count[cost], coins / cost);
            coins -= take * cost;
            ret += take;
        }
        return ret;
    }
}
// @lc code=end

