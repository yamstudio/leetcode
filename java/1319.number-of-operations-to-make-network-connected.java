/*
 * @lc app=leetcode id=1319 lang=java
 *
 * [1319] Number of Operations to Make Network Connected
 */

// @lc code=start
class Solution {
    public int makeConnected(int n, int[][] connections) {
        int k = connections.length;
        if (k < n - 1) {
            return -1;
        }
        int[] parent = new int[n];
        for (int i = 1; i < n; ++i) {
            parent[i] = i;
        }
        for (int[] conn : connections) {
            int l = conn[0], r = conn[1];
            parent[findRoot(parent, l)] = findRoot(parent, r);
        }
        int ret = -1;
        for (int i = 0; i < n; ++i) {
            if (findRoot(parent, i) == i) {
                ++ret;
            }
        }
        return ret;
    }

    private static int findRoot(int[] parent, int curr) {
        if (parent[curr] == curr) {
            return curr;
        }
        int p = findRoot(parent, parent[curr]);
        parent[curr] = p;
        return p;
    }
}
// @lc code=end

