/*
 * @lc app=leetcode id=1028 lang=java
 *
 * [1028] Recover a Tree From Preorder Traversal
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
    
    public TreeNode recoverFromPreorder(String traversal) {
        Stack<Pair> stack = new Stack<>();
        List<Pair> pairs = parse(traversal);
        for (Pair curr : pairs) {
            if (stack.isEmpty()) {
                stack.add(curr);
                continue;
            }
            while (!stack.isEmpty() && stack.peek().level() != curr.level() - 1) {
                stack.pop();
            }
            TreeNode parent = stack.peek().node();
            if (parent.left == null) {
                parent.left = curr.node();
            } else {
                parent.right = curr.node();
            }
            stack.push(curr);
        }
        return pairs.get(0).node();
    }
    
    private static List<Pair> parse(String traversal) {
        int n = traversal.length(), i = 0;
        List<Pair> ret = new ArrayList<>();
        while (i < n) {
            int level = 0, val = 0;
            while (traversal.charAt(i) == '-') {
                ++i;
                ++level;
            }
            while (i < n) {
                char c = traversal.charAt(i);
                if (c == '-') {
                    break;
                }
                ++i;
                val = val * 10 + ((int)c - (int)'0');
            }
            ret.add(new Pair(new TreeNode(val), level));
        }
        return ret;
    }

    private record Pair(TreeNode node, int level) {}
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
