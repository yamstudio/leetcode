/*
 * @lc app=leetcode id=25 lang=csharp
 *
 * [25] Reverse Nodes in k-Group
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

    private ListNode[] ReverseK(ListNode head, int k) {
        if (head == null) {
            return new ListNode[] { null, null };
        }
        ListNode prev = null, curr = head;
        while (curr != null && k > 0) {
            ListNode tmp = curr.next;
            curr.next = prev;
            prev = curr;
            curr = tmp;
            --k;
        }
        if (k == 0) {
            head.next = curr;
            return new ListNode[] { prev, head };
        } else {
            ListNode tail = prev;
            curr = prev;
            prev = null;
            while (curr != head) {
                ListNode tmp = curr.next;
                curr.next = prev;
                prev = curr;
                curr = tmp;
            }
            head.next = prev;
            return new ListNode[] { head, tail };
        }
    }

    public ListNode ReverseKGroup(ListNode head, int k) {
        ListNode[] pack = ReverseK(head, k);
        
        ListNode ret = pack[0], prev = pack[1];
        while (prev != null) {
            pack = ReverseK(prev.next, k);
            prev.next = pack[0];
            prev = pack[1];
        }
        return ret;
    }
}

