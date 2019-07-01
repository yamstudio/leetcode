/*
 * @lc app=leetcode id=19 lang=csharp
 *
 * [19] Remove Nth Node From End of List
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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        ListNode curr = head, tail = head;
        while (n-- > 0) {
            tail = tail.next;
        }
        if (null == tail) {
            return head.next;
        }
        while (null != tail.next) {
            tail = tail.next;
            curr = curr.next;
        }
        curr.next = curr.next.next;
        return head;
    }
}

