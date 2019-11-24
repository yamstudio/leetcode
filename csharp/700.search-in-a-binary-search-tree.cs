/*
 * @lc app=leetcode id=700 lang=csharp
 *
 * [700] Search in a Binary Search Tree
 */

// @lc code=start
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
    public TreeNode SearchBST(TreeNode root, int val) {
        if (root == null) {
            return null;
        }
        int curr = root.val;
        if (curr == val) {
            return root;
        }
        return SearchBST(curr > val ? root.left : root.right, val);
    }
}
// @lc code=end

