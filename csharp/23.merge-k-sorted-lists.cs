/*
 * @lc app=leetcode id=23 lang=csharp
 *
 * [23] Merge k Sorted Lists
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
    public ListNode MergeKLists(ListNode[] lists) {
        int n = lists.Length;
        if (n == 0) {
            return null;
        }
        while (n > 1) {
            for (int i = n % 2; i < n; i += 2) {
                lists[n % 2 + i / 2] = MergeTwoLists(lists[i], lists[i + 1]);
            }
            n = (n + 1) / 2;
        }
        return lists[0];
    }

    private ListNode MergeTwoLists(ListNode l1, ListNode l2) {
        ListNode ret, prev;
        if (l1 == null) {
            return l2;
        }
        if (l2 == null) {
            return l1;
        }
        if (l1.val < l2.val) {
            ret = l1;
            l1 = l1.next;
        } else {
            ret = l2;
            l2 = l2.next;
        }
        prev = ret;
        while (l1 != null && l2 != null) {
            if (l1.val < l2.val) {
                prev.next = l1;
                l1 = l1.next;
            } else {
                prev.next = l2;
                l2 = l2.next;
            }
            prev = prev.next;
        }
        if (l1 != null) {
            prev.next = l1;
        } else {
            prev.next = l2;
        }
        return ret;
    }
}

