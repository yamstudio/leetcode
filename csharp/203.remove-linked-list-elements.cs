/*
 * @lc app=leetcode id=203 lang=csharp
 *
 * [203] Remove Linked List Elements
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
    public ListNode RemoveElements(ListNode head, int val) {
        ListNode ret = null, prev = null;
        while (head != null) {
            if (head.val != val) {
                if (prev == null) {
                    ret = head;
                } else {
                    prev.next = head;
                }
                prev = head;
            }
            head = head.next;
            if (prev != null)
                prev.next = null;
        }
        return ret;
    }
}

