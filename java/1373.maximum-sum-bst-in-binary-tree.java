/*
 * @lc app=leetcode id=1373 lang=java
 *
 * [1373] Maximum Sum BST in Binary Tree
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
    public int maxSumBST(TreeNode root) {
        int[] ret = new int[] { 0 };
        maxSumBst(root, ret);
        return ret[0];
    }

    private static Result maxSumBst(TreeNode root, int[] ret) {
        if (root == null) {
            return new Result(true, 0, null, null);
        }
        Result l = maxSumBst(root.left, ret), r = maxSumBst(root.right, ret);
        if (l.isBst() && r.isBst() && (l.max() == null || l.max() < root.val) && (r.min() == null || r.min() > root.val)) {
            int sum = l.sum() + r.sum() + root.val;
            ret[0] = Math.max(sum, ret[0]);
            return new Result(
                true, 
                sum,
                l.min() == null ? root.val : l.min(),
                r.max() == null ? root.val : r.max()
            );
        }
        return new Result(false, 0, null, null);
    }

    private record Result(boolean isBst, int sum, Integer min, Integer max) {}
}
// @lc code=end

class TreeNode {
    int val;
    TreeNode left;
    TreeNode right;
    TreeNode() {}
    TreeNode(int val) { this.val = val; }
    TreeNode(int val, TreeNode left, TreeNode right) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
