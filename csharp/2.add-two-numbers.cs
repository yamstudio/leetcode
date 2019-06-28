/*
 * @lc app=leetcode id=2 lang=csharp
 *
 * [2] Add Two Numbers
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
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        ListNode ret = l1, prev = null;
        int carry = 0;

        while (true) {
            ListNode curr = null;
            int val1 = 0, val2 = 0, sum = 0;
            if (l1 != null) {
                curr = l1;
                val1 = l1.val;
                l1 = l1.next;
            } else if (l2 == null && carry == 0) {
                break;
            }
            if (l2 != null) {
                if (curr == null) {
                    curr = l2;
                }
                val2 = l2.val;
                l2 = l2.next;
            }
            sum = val1 + val2 + carry;
            if (sum >= 10) {
                sum -= 10;
                carry = 1;
            } else {
                carry = 0;
            }
            if (curr == null) {
                curr = new ListNode(sum);
            } else {
                curr.val = sum;
            }
            if (prev != null) {
                prev.next = curr;
            }
            prev = curr;
        }

        return ret;
    }
}

