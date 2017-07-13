/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode buildTree(int[] preorder, int[] inorder) {
        if (preorder.length != inorder.length)
            return null;
        
        return helper(preorder, 0, preorder.length - 1, inorder, 0, inorder.length - 1);
    }
    
    private TreeNode helper(int[] preorder, int preFrom, int preTo, int[] inorder, int inFrom, int inTo) {
        TreeNode root;
        int index = -1, i;
        
        if (preTo < preFrom || inTo < inFrom)
            return null;
        root = new TreeNode(preorder[preFrom]);
        for (i = inFrom; i <= inTo; ++i) {
            if (inorder[i] == root.val) {
                index = i;
                break;
            }
        }
        if (index < 0)
            return null;
        
        root.left = helper(preorder, preFrom + 1, preFrom + (index - inFrom), inorder, inFrom, index - 1);
        root.right = helper(preorder, preFrom + (index - inFrom + 1), preTo, inorder, index + 1, inTo);
        
        return root;
    }
}
