/*
 * @lc app=leetcode id=1110 lang=java
 *
 * [1110] Delete Nodes And Return Forest
 */

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

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
    public List<TreeNode> delNodes(TreeNode root, int[] toDelete) {
        Set<Integer> deletes = new HashSet<>(toDelete.length + 1);
        deletes.add(-1);
        for (int del : toDelete) {
            deletes.add(del);
        }
        TreeNode sentinel = new TreeNode(-1);
        sentinel.left = root;
        List<TreeNode> ret = new ArrayList<>();
        helper(sentinel, false, deletes, ret);
        return ret;
    }

    private static boolean helper(TreeNode root, boolean disconnected, Set<Integer> deletes, List<TreeNode> ret) {
        if (root == null) {
            return false;
        }
        boolean shouldDelete = deletes.contains(root.val);
        if (disconnected && !shouldDelete) {
            ret.add(root);
        }
        boolean l = helper(root.left, shouldDelete, deletes, ret), r = helper(root.right, shouldDelete, deletes, ret);
        if (l) {
            root.left = null;
        }
        if (r) {
            root.right = null;
        }
        return shouldDelete;
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
