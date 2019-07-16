/*
 * @lc app=leetcode id=92 lang=csharp
 *
 * [92] Reverse Linked List II
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
    public ListNode ReverseBetween(ListNode head, int m, int n) {
        if (m == n) {
            return head;
        }
        ListNode prevTail = null, revTail, curr, next;
        n -= m;
        if (m > 1) {
            prevTail = head;
            --m;
            while (--m > 0) {
                prevTail = prevTail.next;
            }
            next = prevTail.next;
            prevTail.next = null;
        } else {
            next = head;
        }
        revTail = next;
        while (n-- >= 0) {
            curr = next;
            next = curr.next;
            if (prevTail == null) {
                curr.next = head;
                head = curr;
            } else {
                curr.next = prevTail.next;
                prevTail.next = curr;
            }
        }
        revTail.next = next;
        return head;
    }
}

