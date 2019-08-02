/*
 * @lc app=leetcode id=160 lang=csharp
 *
 * [160] Intersection of Two Linked Lists
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

    private int GetLen(ListNode node) {
        return node == null ? 0 : 1 + GetLen(node.next);
    }

    public ListNode GetIntersectionNode(ListNode headA, ListNode headB) {
        int lenA = GetLen(headA), lenB = GetLen(headB);
        if (lenA < lenB) {
            for (int i = 0; i < lenB - lenA; ++i) {
                headB = headB.next;
            }
        } else {
            for (int i = 0; i < lenA - lenB; ++i) {
                headA = headA.next;
            }
        }
        while (headA != headB) {
            headA = headA.next;
            headB = headB.next;
        }
        return headA;
    }
}

