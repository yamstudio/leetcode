/*
 * @lc app=leetcode id=129 lang=csharp
 *
 * [129] Sum Root to Leaf Numbers
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

    private void SumNumbersRecurse(TreeNode root, int[] ret, int curr) {
        if (root == null) {
            return;
        }
        curr = 10 * curr + root.val;
        if (root.left == null && root.right == null) {
            ret[0] += curr;
            return;
        }
        SumNumbersRecurse(root.left, ret, curr);
        SumNumbersRecurse(root.right, ret, curr);
    }

    public int SumNumbers(TreeNode root) {
        int[] ret = new int[] { 0 };
        SumNumbersRecurse(root, ret, 0);
        return ret[0];
    }
}

