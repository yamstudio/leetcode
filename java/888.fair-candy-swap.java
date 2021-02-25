/*
 * @lc app=leetcode id=888 lang=java
 *
 * [888] Fair Candy Swap
 */

// @lc code=start
class Solution {
    public int[] fairCandySwap(int[] A, int[] B) {
        int d = 0;
        Set<Integer> set = new HashSet<Integer>();
        for (int a : A) {
            d += a;
            set.add(a);
        }
        for (int b : B) {
            d -= b;
        }
        d /= 2;
        for (int b : B) {
            if (set.contains(b + d)) {
                return new int[] { b + d, b };
            }
        }
        return new int[0];
    }
}
// @lc code=end

