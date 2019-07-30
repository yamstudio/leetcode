/*
 * @lc app=leetcode id=148 lang=csharp
 *
 * [148] Sort List
 */
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public ListNode SortList(ListNode head) {
        if (head == null || head.next == null) {
            return head;
        }
        ListNode left = head, right = head.next;
        while (right != null && right.next != null) {
            left = left.next;
            right = right.next.next;
        }
        right = left.next;
        left.next = null;
        left = SortList(head);
        right = SortList(right);
        head = null;
        ListNode tail = null;
        while (left != null && right != null) {
            bool isLeft = left.val < right.val;
            ListNode curr = isLeft ? left : right;
            if (head != null) {
                tail.next = curr;
            } else {
                head = curr;
            }
            tail = curr;
            if (isLeft) {
                left = curr.next;
            } else {
                right = curr.next;
            }
            curr.next = null;
        }
        if (left == null) {
            tail.next = right;
        } else {
            tail.next = left;
        }
        return head;
    }
}

