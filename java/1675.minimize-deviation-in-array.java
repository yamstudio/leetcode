/*
 * @lc app=leetcode id=1675 lang=java
 *
 * [1675] Minimize Deviation in Array
 */

// @lc code=start

class Solution {
    public int minimumDeviation(int[] nums) {
        java.util.SortedSet<Integer> sorted = new java.util.TreeSet<>();
        for (int x : nums) {
            if (x % 2 == 1) {
                sorted.add(x * 2);
            } else {
                sorted.add(x);
            }
        }
        int ret = Integer.MAX_VALUE;
        while (true) {
            int min = sorted.first(), max = sorted.last();
            ret = Math.min(ret, max - min);
            if (max % 2 == 1) {
                break;
            }
            sorted.remove(max);
            sorted.add(max / 2);
        }
        return ret;
    }
}
// @lc code=end

