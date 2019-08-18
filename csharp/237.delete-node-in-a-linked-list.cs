/*
 * @lc app=leetcode id=237 lang=csharp
 *
 * [237] Delete Node in a Linked List
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
    public void DeleteNode(ListNode node) {
        ListNode next = node.next;
        while (next != null) {
            node.val = next.val;
            if (next.next == null) {
                break;
            }
            node = next;
            next = next.next;
        }
        node.next = null;
    }
}

