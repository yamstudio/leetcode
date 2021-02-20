/*
 * @lc app=leetcode id=881 lang=java
 *
 * [881] Boats to Save People
 */

// @lc code=start
class Solution {
    public int numRescueBoats(int[] people, int limit) {
        int l = 0, r = people.length - 1, ret = 0;
        Arrays.sort(people);
        while (l < r) {
            if (people[l] + people[r] <= limit) {
                ++l;
            }
            --r;
            ++ret;
        }
        if (l == r) {
            ++ret;
        }
        return ret;
    }
}
// @lc code=end

