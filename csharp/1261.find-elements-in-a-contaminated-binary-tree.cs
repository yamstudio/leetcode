/*
 * @lc app=leetcode id=1261 lang=csharp
 *
 * [1261] Find Elements in a Contaminated Binary Tree
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
public class FindElements {

    private TreeNode Root;

    private static void SetElement(TreeNode root, int val) {
        if (root == null) {
            return;
        }
        root.val = val;
        SetElement(root.left, val * 2 + 1);
        SetElement(root.right, val * 2 + 2);
    }

    public FindElements(TreeNode root) {
        Root = root;
        SetElement(root, 0);
    }
    
    public bool Find(int target) {
        var curr = Root;
        int key = target + 1, len = 0;
        while (key != 0) {
            len++;
            key >>= 1;
        }
        key = target + 1;
        for (int i = len - 1; i > 0 && curr != null; --i) {
            if ((key & (1 << (i - 1))) != 0) {
                curr = curr.right;
            } else {
                curr = curr.left;
            }
        }
        return curr != null;
    }
}

/**
 * Your FindElements object will be instantiated and called as such:
 * FindElements obj = new FindElements(root);
 * bool param_1 = obj.Find(target);
 */
// @lc code=end

