/*
 * @lc app=leetcode id=1483 lang=java
 *
 * [1483] Kth Ancestor of a Tree Node
 */

// @lc code=start
class TreeAncestor {

    private final int[][] jump;

    public TreeAncestor(int n, int[] parent) {
        int levels = (int)(Math.log(n) / Math.log(2)) + 1;
        jump = new int[n][levels];
        for (int i = 0; i < n; ++i) {
            jump[i][0] = parent[i];
        }
        for (int l = 1; l < levels; ++l) {
            for (int i = 0; i < n; ++i) {
                int p = jump[i][l - 1];
                if (p == -1) {
                    jump[i][l] = -1;
                } else {
                    jump[i][l] = jump[p][l - 1];
                }
            }
        }
    }
    
    public int getKthAncestor(int node, int k) {
        int levels = jump[0].length;
        for (int l = 0; l < levels; ++l) {
            if ((k & (1 << l)) != 0) {
                node = jump[node][l];
                if (node == -1) {
                    return -1;
                }
            }
        }
        return node;
    }
}

/**
 * Your TreeAncestor object will be instantiated and called as such:
 * TreeAncestor obj = new TreeAncestor(n, parent);
 * int param_1 = obj.getKthAncestor(node,k);
 */
// @lc code=end

