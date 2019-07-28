/*
 * @lc app=leetcode id=143 lang=csharp
 *
 * [143] Reorder List
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
    public void ReorderList(ListNode head) {
        ListNode slow = head, fast = head;
        while (fast != null && fast.next != null) {
            slow = slow.next;
            fast = fast.next.next;
        }
        if (slow == null) {
            return;
        }
        ListNode curr = slow.next;
        slow.next = null;
        fast = null;
        while (curr != null) {
            ListNode tmp = curr.next;
            curr.next = fast;
            fast = curr;
            curr = tmp;
        }
        while (fast != null) {
            ListNode tmp = fast.next;
            slow = head.next;
            head.next = fast;
            fast.next = slow;
            head = slow;
            fast = tmp;
        }
    }
}

