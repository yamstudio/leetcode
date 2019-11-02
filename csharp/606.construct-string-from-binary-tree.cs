/*
 * @lc app=leetcode id=606 lang=csharp
 *
 * [606] Construct String from Binary Tree
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
    public string Tree2str(TreeNode t) {
        if (t == null) {
            return "";
        }
        string left = Tree2str(t.left);
        string right = Tree2str(t.right);
        if (left == "") {
            return right == "" ? t.val.ToString() : $"{t.val}()({right})";
        }
        return right == "" ? $"{t.val}({left})" : $"{t.val}({left})({right})";
    }
}
// @lc code=end

