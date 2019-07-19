/*
 * @lc app=leetcode id=106 lang=csharp
 *
 * [106] Construct Binary Tree from Inorder and Postorder Traversal
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

    private TreeNode BuildTreeRecursive(int[] inorder, int[] postorder, int iStart, int iEnd, int pStart, int pEnd) {
        if (pStart > pEnd) {
            return null;
        }
        int val = postorder[pEnd];
        TreeNode ret = new TreeNode(val);
        int leftEnd = iStart - 1;
        while (leftEnd < iEnd) {
            if (inorder[leftEnd + 1] == val) {
                break;
            }
            ++leftEnd;
        }
        int leftLen = leftEnd - iStart + 1;
        ret.left = BuildTreeRecursive(inorder, postorder, iStart, leftEnd, pStart, pStart + leftLen - 1);
        ret.right = BuildTreeRecursive(inorder, postorder, leftEnd + 2, iEnd, pStart + leftLen, pEnd - 1);
        return ret;
    }

    public TreeNode BuildTree(int[] inorder, int[] postorder) {
        int len = inorder.Length;
        return BuildTreeRecursive(inorder, postorder, 0, len - 1, 0, len - 1);
    }
}

