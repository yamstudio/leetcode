/*
 * @lc app=leetcode id=1305 lang=java
 *
 * [1305] All Elements in Two Binary Search Trees
 */

import java.util.ArrayList;
import java.util.List;
import java.util.Stack;

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
    public List<Integer> getAllElements(TreeNode root1, TreeNode root2) {
        List<Integer> ret = new ArrayList<>();
        Stack<TreeNode> stack1 = new Stack<>(), stack2 = new Stack<>();
        helper(root1, stack1);
        helper(root2, stack2);
        while (!stack1.empty() || !stack2.empty()) {
            Stack<TreeNode> stack = stack1.empty() ? stack2 : (stack2.empty() ? stack1 : stack1.peek().val < stack2.peek().val ? stack1 : stack2);
            TreeNode curr = stack.pop();
            ret.add(curr.val);
            helper(curr.right, stack);
        }
        return ret;
    }

    private static void helper(TreeNode curr, Stack<TreeNode> stack) {
        while (curr != null) {
            stack.push(curr);
            curr = curr.left;
        }
    }
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
