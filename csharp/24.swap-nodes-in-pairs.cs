/*
 * @lc app=leetcode id=24 lang=csharp
 *
 * [24] Swap Nodes in Pairs
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
    public ListNode SwapPairs(ListNode head) {
        ListNode ret, prev, curr;
        if (head == null || head.next == null) {
            return head;
        }
        ret = head.next;
        curr = ret.next;
        prev = head;
        prev.next = null;
        ret.next = prev;
        while (curr != null) {
            if (curr.next == null) {
                prev.next = curr;
                curr = null;
            } else {
                ListNode tmp = curr.next.next;
                prev.next = curr.next;
                prev.next.next = curr;
                prev = curr;
                prev.next = null;
                curr = tmp;
            }
        }
        return ret;
    }
}

