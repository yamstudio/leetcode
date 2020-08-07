/*
 * @lc app=leetcode id=998 lang=csharp
 *
 * [998] Maximum Binary Tree II
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

    private static void InsertIntoMaxTreeRecurse(TreeNode parent, TreeNode curr, int val) {
        if (curr == null || curr.val < val) {
            parent.right = new TreeNode(val, curr, null);
        } else {
            InsertIntoMaxTreeRecurse(curr, curr.right, val);
        }
    }

    public TreeNode InsertIntoMaxTree(TreeNode root, int val) {
        var sentinel = new TreeNode(int.MaxValue, null, root);
        InsertIntoMaxTreeRecurse(sentinel, root, val);
        return sentinel.right;
    }
}
// @lc code=end

