/*
 * @lc app=leetcode id=1080 lang=csharp
 *
 * [1080] Insufficient Nodes in Root to Leaf Paths
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

    private static bool SufficientSubsetRecurse(TreeNode root, int sum) {
        sum += root.val;
        if (root.left == null) {
            if (root.right == null) {
                return sum < 0;
            }
            return SufficientSubsetRecurse(root.right, sum);
        }
        if (root.right == null) {
            return SufficientSubsetRecurse(root.left, sum);
        }
        bool isLeftInsufficient = SufficientSubsetRecurse(root.left, sum), isRightInsufficient = SufficientSubsetRecurse(root.right, sum);
        if (isLeftInsufficient && isRightInsufficient) {
            return true;
        }
        if (isLeftInsufficient) {
            root.left = null;
        }
        if (isRightInsufficient) {
            root.right = null;
        }
        return false;
    }

    public TreeNode SufficientSubset(TreeNode root, int limit) {
        return SufficientSubsetRecurse(root, -limit) ? null : root;
    }
}
// @lc code=end

