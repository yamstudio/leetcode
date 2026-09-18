/*
 * @lc app=leetcode id=1823 lang=java
 *
 * [1823] Find the Winner of the Circular Game
 */

// @lc code=start
class Solution {
    public int findTheWinner(int n, int k) {
        return find(n, k) + 1;
    }

    private static int find(int n, int k) {
        if (n == 1) {
            return 0;
        }
        return (find(n - 1, k) + k) % n;
    }
}
// @lc code=end

