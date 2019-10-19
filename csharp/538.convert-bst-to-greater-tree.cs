/*
 * @lc app=leetcode id=538 lang=csharp
 *
 * [538] Convert BST to Greater Tree
 */

using System.Collections.Generic;

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
    public TreeNode ConvertBST(TreeNode root) {
        if (root == null) {
            return null;
        }
        int sum = 0;
        IList<TreeNode> stack = new List<TreeNode>();
        var curr = root;
        while (stack.Count != 0 || curr != null) {
            while (curr != null) {
                stack.Add(curr);
                curr = curr.right;
            }
            curr = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);
            sum += curr.val;
            curr.val = sum;
            curr = curr.left;
        }
        return root;
    }
}
// @lc code=end

