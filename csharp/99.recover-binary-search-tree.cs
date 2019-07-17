/*
 * @lc app=leetcode id=99 lang=csharp
 *
 * [99] Recover Binary Search Tree
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
public class Solution {
    public void RecoverTree(TreeNode root) {
        TreeNode curr = root, pre = null, parent = null, first = null, second = null;
        while (curr != null) {
            if (curr.left == null) {
                if (parent != null && parent.val > curr.val) {
                    if (first == null) {
                        first = parent;
                    }
                    second = curr;
                }
                parent = curr;
                curr = curr.right;
            } else {
                pre = curr.left;
                while (pre.right != null && pre.right != curr) {
                    pre = pre.right;
                }
                if (pre.right == curr) {
                    pre.right = null;
                    if (parent.val > curr.val) {
                        if (first == null) {
                            first = parent;
                        }
                        second = curr;
                    }
                    parent = curr;
                    curr = curr.right;
                } else {
                    pre.right = curr;
                    curr = curr.left;
                }
            }
        }
        int tmp = first.val;
        first.val = second.val;
        second.val = tmp;
    }
}

