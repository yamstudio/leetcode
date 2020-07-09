/*
 * @lc app=leetcode id=919 lang=csharp
 *
 * [919] Complete Binary Tree Inserter
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
public class CBTInserter {

    private TreeNode Root;
    private Queue<TreeNode> Queue;

    public CBTInserter(TreeNode root) {
        Root = root;
        Queue = new Queue<TreeNode>();
        Queue.Enqueue(root);
        while (true) {
            var first = Queue.Peek();
            if (first.left == null || first.right == null) {
                break;
            }
            Queue.Enqueue(first.left);
            Queue.Enqueue(first.right);
            Queue.Dequeue();
        }
    }
    
    public int Insert(int v) {
        var node = new TreeNode(v);
        var first = Queue.Peek();
        if (first.left == null) {
            first.left = node;
        } else {
            first.right = node;
            Queue.Dequeue();
        }
        Queue.Enqueue(node);
        return first.val;
    }
    
    public TreeNode Get_root() {
        return Root;
    }
}

/**
 * Your CBTInserter object will be instantiated and called as such:
 * CBTInserter obj = new CBTInserter(root);
 * int param_1 = obj.Insert(v);
 * TreeNode param_2 = obj.Get_root();
 */
// @lc code=end

