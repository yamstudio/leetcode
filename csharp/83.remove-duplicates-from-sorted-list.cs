/*
 * @lc app=leetcode id=83 lang=csharp
 *
 * [83] Remove Duplicates from Sorted List
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
    public ListNode DeleteDuplicates(ListNode head) {
        ListNode ret = null, curr = head, prev = null;
        while (curr != null) {
            if (prev == null || prev.val != curr.val) {
                ListNode tmp = curr.next;
                if (prev != null) {
                    prev.next = curr;
                } else {
                    ret = curr;
                }
                prev = curr;
                curr.next = null;
                curr = tmp;
            } else {
                curr = curr.next;
            }
        }
        return ret;
    }
}

