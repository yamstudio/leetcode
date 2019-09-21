/*
 * @lc app=leetcode id=445 lang=csharp
 *
 * [445] Add Two Numbers II
 */
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */

using System.Collections.Generic;

public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        IList<ListNode> s1 = new List<ListNode>(), s2 = new List<ListNode>(), longer, shorter;
        ListNode curr = l1;
        while (curr != null) {
            s1.Add(curr);
            curr = curr.next;
        }
        curr = l2;
        while (curr != null) {
            s2.Add(curr);
            curr = curr.next;
        }
        if (s1.Count > s2.Count) {
            longer = s1;
            shorter = s2;
        } else {
            longer = s2;
            shorter = s1;
        }
        int carry = 0;
        for (int i = 1; i <= shorter.Count; ++i) {
            ListNode n1 = longer[longer.Count - i], n2 = shorter[shorter.Count - i];
            int sum = n1.val + n2.val + carry;
            if (sum >= 10) {
                sum -= 10;
                carry = 1;
            } else {
                carry = 0;
            }
            n1.val = sum;
        }
        for (int i = shorter.Count + 1; i <= longer.Count && carry == 1; ++i) {
            curr = longer[longer.Count - i];
            if (curr.val == 9) {
                curr.val = 0;
            } else {
                curr.val += 1;
                carry = 0;
            }
        }
        if (carry == 0) {
            return longer[0];
        } else {
            curr = new ListNode(1);
            curr.next = longer[0];
            return curr;
        }
    }
}

