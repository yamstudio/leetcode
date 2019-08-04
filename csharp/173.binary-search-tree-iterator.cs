/*
 * @lc app=leetcode id=173 lang=csharp
 *
 * [173] Binary Search Tree Iterator
 */
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

using System.Collections.Generic;

public class BSTIterator {

    private IList<TreeNode> stack;

    public BSTIterator(TreeNode root) {
        stack = new List<TreeNode>();
        while (root != null) {
            stack.Add(root);
            root = root.left;
        }
    }
    
    /** @return the next smallest number */
    public int Next() {
        TreeNode node = stack[stack.Count - 1];
        stack.RemoveAt(stack.Count - 1);
        int ret = node.val;
        node = node.right;
        while (node != null) {
            stack.Add(node);
            node = node.left;
        }
        return ret;
    }
    
    /** @return whether we have a next smallest number */
    public bool HasNext() {
        return stack.Count > 0;
    }
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */

