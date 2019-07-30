/*
 * @lc app=leetcode id=147 lang=csharp
 *
 * [147] Insertion Sort List
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
    public ListNode InsertionSortList(ListNode head) {
        ListNode minHead = new ListNode(int.MinValue);
        minHead.next = null;

        while (head != null) {
            ListNode curr = head, insert = minHead;
            head = head.next;
            while (insert.next != null && insert.next.val < curr.val) {
                insert = insert.next;
            }
            curr.next = insert.next;
            insert.next = curr;
        }

        return minHead.next;
    }
}

