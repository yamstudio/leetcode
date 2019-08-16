/*
 * @lc app=leetcode id=230 lang=csharp
 *
 * [230] Kth Smallest Element in a BST
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

    private (int, bool) KthSmallestRecurse(TreeNode root, int k) {
        if (root == null) {
            return (0, false);
        }

        var (lval, lfound) = KthSmallestRecurse(root.left, k);
        if (lfound) {
            return (lval, lfound);
        }
        if (lval == k - 1) {
            return (root.val, true);
        }

        var (rval, rfound) = KthSmallestRecurse(root.right, k - lval - 1);
        if (rfound) {
            return (rval, rfound);
        }
        return (lval + 1 + rval, false);
    }

    public int KthSmallest(TreeNode root, int k) {
        return KthSmallestRecurse(root, k).Item1;
    }
}

