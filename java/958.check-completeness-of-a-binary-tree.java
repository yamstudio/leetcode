/*
 * @lc app=leetcode id=958 lang=java
 *
 * [958] Check Completeness of a Binary Tree
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

    private static final int BAD = -1;
    private static final int PERFECT = 1 << 11;

    public boolean isCompleteTree(TreeNode root) {
        return getCompletenessDepth(root) >= 0;
    }

    private int getCompletenessDepth(TreeNode root) {
        if (root == null) {
            return PERFECT;
        }
        int l = getCompletenessDepth(root.left), r = getCompletenessDepth(root.right);
        if (l == BAD || r == BAD) {
            return BAD;
        }
        int lp = PERFECT & l, rp = PERFECT & r, ld = l ^ lp, rd = r ^ rp;
        if (ld < rd || ld > rd + 1) {
            return BAD;
        }
        if (ld == rd) {
            if (lp == 0) {
                return BAD;
            }
            return rp | (1 + ld);
        }
        if (rp == 0) {
            return BAD;
        }
        return 1 + ld;
    }
}
// @lc code=end

class TreeNode {
    int val;
    TreeNode left;
    TreeNode right;
}
