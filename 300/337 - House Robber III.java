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
    public int rob(TreeNode root) {
        int[] ret = dfs(root);
        
        return Math.max(ret[0], ret[1]);
    }
    
    private int[] dfs(TreeNode root) {
        int[] ret = {0, 0}, l, r;
        
        if (root == null)
            return ret;
        
        l = dfs(root.left);
        r = dfs(root.right);
        ret[0] = Math.max(l[0], l[1]) + Math.max(r[0], r[1]);
        ret[1] = l[0] + r[0] + root.val;
        
        return ret;
    }
}
