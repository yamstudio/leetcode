/*
 * @lc app=leetcode id=109 lang=csharp
 *
 * [109] Convert Sorted List to Binary Search Tree
 */
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    public TreeNode SortedListToBST(ListNode head) {
        if (head == null) {
            return null;
        }
        if (head.next == null) {
            return new TreeNode(head.val);
        }
        ListNode fast = head, slow = head, leftTail = head;
        TreeNode ret;
        while (fast.next != null && fast.next.next != null) {
            fast = fast.next.next;
            leftTail = slow;
            slow = slow.next;
        }
        fast = slow.next;
        leftTail.next = null;
        ret = new TreeNode(slow.val);
        if (slow != head) {
            ret.left = SortedListToBST(head);
        }
        ret.right = SortedListToBST(fast);
        return ret;
    }
}

