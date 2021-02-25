/*
 * @lc app=leetcode id=889 lang=java
 *
 * [889] Construct Binary Tree from Preorder and Postorder Traversal
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

    private static TreeNode construct(int[] pre, int[] post, int[] map, int l, int r, int len) {
        if (len == 0) {
            return null;
        }
        TreeNode ret = new TreeNode(pre[l]);
        if (len > 1) {
            int rr = map[pre[l + 1]];
            ret.left = construct(pre, post, map, l + 1, r, rr - r + 1);
            ret.right = construct(pre, post, map, l + 1 + (rr - r + 1), rr + 1, len - 1 - (rr - r + 1));
        }
        return ret;
    }

    public TreeNode constructFromPrePost(int[] pre, int[] post) {
        int n = pre.length;
        int[] map = new int[n + 1];
        for (int i = 0; i < n; ++i) {
            map[post[i]] = i;
        }
        return construct(pre, post, map, 0, 0, n);
    }
}
// @lc code=end

