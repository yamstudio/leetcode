/*
 * @lc app=leetcode id=971 lang=java
 *
 * [971] Flip Binary Tree To Match Preorder Traversal
 */

import java.util.ArrayList;
import java.util.List;

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
    public List<Integer> flipMatchVoyage(TreeNode root, int[] voyage) {
        List<Integer> ret = new ArrayList<>();
        if (voyage.length == flipMatchVoyage(root, voyage, 0, ret)) {
            return ret;
        }
        return List.of(-1);
    }
    
    private static int flipMatchVoyage(TreeNode root, int[] voyage, int currIndex, List<Integer> result) {
        if (root == null) {
            return currIndex;
        }
        if (root.val != voyage[currIndex]) {
            return -1;
        }
        int lret = flipMatchVoyage(root.left, voyage, currIndex + 1, result);
        if (lret >= 0) {
            return flipMatchVoyage(root.right, voyage, lret, result);
        }
        int rret = flipMatchVoyage(root.right, voyage, currIndex + 1, result);
        if (rret >= 0) {
            result.add(root.val);
            return flipMatchVoyage(root.left, voyage, rret, result);
        }
        return -1;
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