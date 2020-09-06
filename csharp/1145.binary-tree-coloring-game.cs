/*
 * @lc app=leetcode id=1145 lang=csharp
 *
 * [1145] Binary Tree Coloring Game
 */

using System;

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {

    private static int CountRecurse(TreeNode root, int x, ref int lx, ref int rx) {
        if (root == null) {
            return 0;
        }
        int left = CountRecurse(root.left, x, ref lx, ref rx), right = CountRecurse(root.right, x, ref lx, ref rx);
        if (x == root.val) {
            lx = left;
            rx = right;
        }
        return left + right + 1;
    }

    public bool BtreeGameWinningMove(TreeNode root, int n, int x) {
        int lx = 0, rx = 0;
        CountRecurse(root, x, ref lx, ref rx);
        int px = n - lx - rx - 1;
        return Math.Max(px, Math.Max(lx, rx)) > n / 2;
    }
}
// @lc code=end

