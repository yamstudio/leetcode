/*
 * @lc app=leetcode id=1483 lang=csharp
 *
 * [1483] Kth Ancestor of a Tree Node
 */

using System;

// @lc code=start
public class TreeAncestor {

    private static int Levels;
    private static int[,] Jump;

    public TreeAncestor(int n, int[] parent) {
        Levels = (int)Math.Log(n, 2) + 1;
        Jump = new int[Levels, n];
        for (int j = 0; j < n; ++j) {
            Jump[0, j] = parent[j];
        }
        for (int i = 1; i < Levels; ++i) {
            for (int j = 0; j < n; ++j) {
                int p = Jump[i - 1, j];
                if (p == -1) {
                    Jump[i, j] = -1;
                } else {
                    Jump[i, j] = Jump[i - 1, p];
                }
            }
        }
    }
    
    public int GetKthAncestor(int node, int k) {
        for (int i = 0; i < Levels; ++i) {
            if ((k & (1 << i)) != 0) {
                node = Jump[i, node];
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
 * int param_1 = obj.GetKthAncestor(node,k);
 */
// @lc code=end

