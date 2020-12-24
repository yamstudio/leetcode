/*
 * @lc app=leetcode id=1609 lang=csharp
 *
 * [1609] Even Odd Tree
 */

using System.Collections.Generic;

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
    public bool IsEvenOddTree(TreeNode root) {
        bool isOdd = true;
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count > 0) {
            int k = queue.Count, p = isOdd ? int.MinValue : int.MaxValue;
            while (k-- > 0) {
                var curr = queue.Dequeue();
                if (curr == null) {
                    continue;
                }
                if (isOdd) {
                    if (curr.val % 2 == 0 || curr.val <= p) {
                        return false;
                    }
                } else {
                    if (curr.val % 2 == 1 || curr.val >= p) {
                        return false;
                    }
                }
                p = curr.val;
                queue.Enqueue(curr.left);
                queue.Enqueue(curr.right);
            }
            isOdd = !isOdd;
        }
        return true;
    }
}
// @lc code=end

