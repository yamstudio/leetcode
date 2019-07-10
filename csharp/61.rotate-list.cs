/*
 * @lc app=leetcode id=61 lang=csharp
 *
 * [61] Rotate List
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
    public ListNode RotateRight(ListNode head, int k) {
        int len = 0;
        ListNode curr = head, tmp = null;
        if (head == null) {
            return null;
        }
        while (curr != null) {
            ++len;
            curr = curr.next;
        }
        k = len - k % len;
        if (k == len) {
            return head;
        }
        curr = head;
        while (k-- > 0) {
            tmp = curr;
            curr = curr.next;
        }
        tmp.next = null;
        tmp = curr;
        while (tmp.next != null) {
            tmp = tmp.next;
        }
        tmp.next = head;
        return curr;
    }
}

