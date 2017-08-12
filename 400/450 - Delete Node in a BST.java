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
    public TreeNode deleteNode(TreeNode root, int key) {
        TreeNode left, right, temp;
        
        if (root == null)
            return null;
        
        left = root.left;
        right = root.right;
        
        if (root.val > key) {
            root.left = deleteNode(left, key);
            return root;
        }
        
        if (root.val < key) {
            root.right = deleteNode(right, key);
            return root;
        }

        if (left == null)
            return right;
        if (right == null)
            return left;

        temp = left;
        while (temp.right != null)
            temp = temp.right;
        
        temp.right = right.left;
        right.left = left;
        
        return right;
    }
}
