/*
 * @lc app=leetcode id=865 lang=csharp
 *
 * [865] Smallest Subtree with all the Deepest Nodes
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    
    private static (int Depth, TreeNode Node) SubtreeWithAllDeepestRecurse(TreeNode root) {
        if (root == null) {
            return (Depth: 0, Node: null);
        }
        var left = SubtreeWithAllDeepestRecurse(root.left);
        var right = SubtreeWithAllDeepestRecurse(root.right);
        int depth = left.Depth;
        if (depth > right.Depth) {
            root = left.Node;
        } else if (depth < right.Depth) {
            depth = right.Depth;
            root = right.Node;
        }
        return (Depth: depth + 1, Node: root);
    }
    
    public TreeNode SubtreeWithAllDeepest(TreeNode root) {
        return SubtreeWithAllDeepestRecurse(root).Node;
    }
}
// @lc code=end

