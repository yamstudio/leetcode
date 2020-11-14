/*
 * @lc app=leetcode id=1448 lang=csharp
 *
 * [1448] Count Good Nodes in Binary Tree
 */

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

    private static int GoodNodes(TreeNode root, int max) {
        if (root == null) {
            return 0;
        }
        if (max <= root.val) {
            return 1 + GoodNodes(root.left, root.val) + GoodNodes(root.right, root.val);
        }
        return GoodNodes(root.left, max) + GoodNodes(root.right, max);
    }

    public int GoodNodes(TreeNode root) {
        return GoodNodes(root, int.MinValue);
    }
}
// @lc code=end

