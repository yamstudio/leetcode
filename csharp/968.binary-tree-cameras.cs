/*
 * @lc app=leetcode id=968 lang=csharp
 *
 * [968] Binary Tree Cameras
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {

    private static (int Count, int State) MinCameraCoverRecurse(TreeNode root) {
        if (root == null) {
            return (Count: 0, State: 1);
        }
        var left = MinCameraCoverRecurse(root.left);
        var right = MinCameraCoverRecurse(root.right);
        if (left.State == 0 || right.State == 0) {
            return (Count: left.Count + right.Count + 1, State: 2);
        }
        if (left.State == 2 || right.State == 2) {
            return (Count: left.Count + right.Count, State: 1);
        }
        return (Count: left.Count + right.Count, State: 0);
    }

    public int MinCameraCover(TreeNode root) {
        var r = MinCameraCoverRecurse(root);
        return r.State == 0 ? r.Count + 1 : r.Count;
    }
}
// @lc code=end

