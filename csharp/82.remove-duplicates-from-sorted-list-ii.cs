/*
 * @lc app=leetcode id=82 lang=csharp
 *
 * [82] Remove Duplicates from Sorted List II
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
            int val = curr.val;
            if (curr.next == null || val != curr.next.val) {
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
                while (curr != null && curr.val == val) {
                    curr = curr.next;
                }
            }
        }
        return ret;
    }
}

