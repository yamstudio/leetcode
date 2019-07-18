/*
 * @lc app=leetcode id=105 lang=csharp
 *
 * [105] Construct Binary Tree from Preorder and Inorder Traversal
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

    private TreeNode BuildTreeRecursive(int[] preorder, int[] inorder, int pStart, int pEnd, int iStart, int iEnd) {
        if (pStart > pEnd) {
            return null;
        }
        int val = preorder[pStart];
        TreeNode ret = new TreeNode(val);
        int leftEnd = iStart - 1;
        while (leftEnd < iEnd) {
            if (inorder[leftEnd + 1] == val) {
                break;
            }
            ++leftEnd;
        }
        int leftLen = leftEnd - iStart + 1;
        ret.left = BuildTreeRecursive(preorder, inorder, pStart + 1, pStart + leftLen, iStart, leftEnd);
        ret.right = BuildTreeRecursive(preorder, inorder, pStart + leftLen + 1, pEnd, leftEnd + 2, iEnd);
        return ret;
    }

    public TreeNode BuildTree(int[] preorder, int[] inorder) {
        int len = preorder.Length;
        return BuildTreeRecursive(preorder, inorder, 0, len - 1, 0, len - 1);
    }
}

