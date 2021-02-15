/*
 * @lc app=leetcode id=872 lang=java
 *
 * [872] Leaf-Similar Trees
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
class Solution {

    private static void addLeaves(TreeNode root, List<Integer> ret) {
        if (root.left == null) {
            if (root.right == null) {
                ret.add(root.val);
            } else {
                addLeaves(root.right, ret);
            }
        } else {
            addLeaves(root.left, ret);
            if (root.right != null) {
                addLeaves(root.right, ret);
            }
        }
    }

    public boolean leafSimilar(TreeNode root1, TreeNode root2) {
        List<Integer> l1 = new ArrayList<Integer>(), l2 = new ArrayList<Integer>();
        addLeaves(root1, l1);
        addLeaves(root2, l2);
        int n = l1.size();
        if (n != l2.size()) {
            return false;
        }
        for (int i = 0; i < n; ++i) {
            if (l1.get(i) != l2.get(i)) {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

