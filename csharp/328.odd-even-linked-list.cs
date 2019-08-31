/*
 * @lc app=leetcode id=328 lang=csharp
 *
 * [328] Odd Even Linked List
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
    public ListNode OddEvenList(ListNode head) {
        ListNode oddTail, evenHead, evenTail, curr;
        bool addToOdd = true;
        if (head == null || head.next == null) {
            return head;
        }
        oddTail = head;
        evenHead = oddTail.next;
        oddTail.next = null;
        evenTail = evenHead;
        curr = evenTail.next;
        evenTail.next = null;
        while (curr != null) {
            ListNode tmp = curr.next;
            curr.next = null;
            if (addToOdd) {
                oddTail.next = curr;
                oddTail = curr;
            } else {
                evenTail.next = curr;
                evenTail = curr;
            }
            addToOdd = !addToOdd;
            curr = tmp;
        }
        oddTail.next = evenHead;
        return head;
    }
}

