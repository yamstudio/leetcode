/*
 * @lc app=leetcode id=919 lang=java
 *
 * [919] Complete Binary Tree Inserter
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode() {}
 *     TreeNode(int val) { this.val = val; }
 *     TreeNode(int val, TreeNode left, TreeNode right) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
class CBTInserter {

    private List<TreeNode> nodes;

    public CBTInserter(TreeNode root) {
        nodes = new ArrayList<TreeNode>();
        nodes.add(root);
        for (int i = 0; i < nodes.size(); ++i) {
            TreeNode node = nodes.get(i);
            if (node.left != null) {
                nodes.add(node.left);
            }
            if (node.right != null) {
                nodes.add(node.right);
            }
        }
    }
    
    public int insert(int v) {
        int n = nodes.size(), i = (n - 1) / 2;
        TreeNode parent = nodes.get(i), node = new TreeNode(v);
        nodes.add(node);
        if (n % 2 == 1) {
            parent.left = node;
        } else {
            parent.right = node;
        }
        return parent.val;
    }
    
    public TreeNode get_root() {
        return nodes.get(0);
    }
}

/**
 * Your CBTInserter object will be instantiated and called as such:
 * CBTInserter obj = new CBTInserter(root);
 * int param_1 = obj.insert(v);
 * TreeNode param_2 = obj.get_root();
 */
// @lc code=end

