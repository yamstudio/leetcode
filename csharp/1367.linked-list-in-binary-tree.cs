/*
 * @lc app=leetcode id=1367 lang=csharp
 *
 * [1367] Linked List in Binary Tree
 */

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
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

    private static bool IsSubPathFrom(ListNode head, TreeNode root) {
        if (head == null) {
            return true;
        }
        if (root == null) {
            return false;
        }
        return head.val == root.val && (IsSubPathFrom(head.next, root.left) || IsSubPathFrom(head.next, root.right));
    }

    public bool IsSubPath(ListNode head, TreeNode root) {
        return root != null && (IsSubPathFrom(head, root) || IsSubPath(head, root.left) || IsSubPath(head, root.right));
    }
}
// @lc code=end

