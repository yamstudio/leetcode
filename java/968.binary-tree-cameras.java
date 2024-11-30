/*
 * @lc app=leetcode id=968 lang=java
 *
 * [968] Binary Tree Cameras
 */

import java.util.HashMap;
import java.util.Map;

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
    public int minCameraCover(TreeNode root) {
        return minCameraCover(root, State.PARENT_COVERED, new HashMap<>());
    }

    private static int minCameraCover(TreeNode root, State state, Map<CacheKey, Integer> memo) {
        if (root == null) {
            return 0;
        }
        CacheKey key = new CacheKey(root, state);
        Integer cached = memo.get(key);
        if (cached != null) {
            return cached;
        }
        int ret = 1 + minCameraCover(root.left, State.PARENT_INSTALLED, memo) + minCameraCover(root.right, State.PARENT_INSTALLED, memo);
        if (state == State.PARENT_INSTALLED) {
            ret = Math.min(ret, minCameraCover(root.left, State.PARENT_COVERED, memo) + minCameraCover(root.right, State.PARENT_COVERED, memo));
        } else if (state == State.PARENT_COVERED) {
            if (root.left != null) {
                ret = Math.min(ret, minCameraCover(root.left, State.PARENT_UNCOVERED, memo) + minCameraCover(root.right, State.PARENT_COVERED, memo));
            }
            if (root.right != null) {
                ret = Math.min(ret, minCameraCover(root.left, State.PARENT_COVERED, memo) + minCameraCover(root.right, State.PARENT_UNCOVERED, memo));
            }
        }
        memo.put(key, ret);
        return ret;
    }

    private enum State {
        PARENT_INSTALLED,
        PARENT_COVERED,
        PARENT_UNCOVERED
    }

    private record CacheKey(TreeNode node, State state) {}
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
