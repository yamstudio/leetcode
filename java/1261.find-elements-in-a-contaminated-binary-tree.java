/*
 * @lc app=leetcode id=1261 lang=java
 *
 * [1261] Find Elements in a Contaminated Binary Tree
 */

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
class FindElements {

    private final TreeNode root;

    public FindElements(TreeNode root) {
        this.root = root;
        set(root, 0);
    }
    
    public boolean find(int target) {
        int key = target + 1, l = 0;
        while (key != 0) {
            ++l;
            key >>= 1;
        }
        TreeNode curr = root;
        key = target + 1;
        for (int i = l - 1; i > 0 && curr != null; --i) {
            if (((1 << (i - 1)) & key) == 0) {
                curr = curr.left;
            } else {
                curr = curr.right;
            }
        }
        return curr != null;
    }

    private static void set(TreeNode curr, int target) {
        if (curr == null) {
            return;
        }
        curr.val = target;
        set(curr.left, 2 * target + 1);
        set(curr.right, 2 * target + 2);
    }
}

/**
 * Your FindElements object will be instantiated and called as such:
 * FindElements obj = new FindElements(root);
 * boolean param_1 = obj.find(target);
 */
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
