/*
 * @lc app=leetcode id=988 lang=csharp
 *
 * [988] Smallest String Starting From Leaf
 */

using System.Text;

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

    private static void SmallestFromLeafRecurse(TreeNode root, StringBuilder sb, ref string ret) {
        if (root == null) {
            return;
        }
        sb.Insert(0, (char)((int)'a' + root.val));
        if (root.left == null && root.right == null) {
            string curr = sb.ToString();
            if (ret == null || curr.CompareTo(ret) < 0) {
                ret = curr;
            }
        } else {
            SmallestFromLeafRecurse(root.left, sb, ref ret);
            SmallestFromLeafRecurse(root.right, sb, ref ret);
        }
        sb.Remove(0, 1);
    }

    public string SmallestFromLeaf(TreeNode root) {
        string ret = null;
        SmallestFromLeafRecurse(root, new StringBuilder(), ref ret);
        return ret;
    }
}
// @lc code=end

