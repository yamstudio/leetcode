/*
 * @lc app=leetcode id=86 lang=csharp
 *
 * [86] Partition List
 */
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */

class Group {
    public ListNode Head { get; set; }
    public ListNode Tail { get; set; }

    public Group() {
        Head = null;
        Tail = null;
    }

    public ListNode Add(ListNode node) {
        if (Head != null) {
            Tail.next = node;
        } else {
            Head = node;
        }
        ListNode ret = node.next;
        node.next = null;
        Tail = node;
        return ret;
    }

    public void Append(Group group) {
        if (Head == null) {
            Head = group.Head;
        } else {
            Tail.next = group.Head;
        }
        Tail = group.Tail;
    }
}

public class Solution {
    public ListNode Partition(ListNode head, int x) {
        Group lt = new Group(), ge = new Group();
        ListNode curr = head;
        while (curr != null) {
            Group which = curr.val < x ? lt : ge;
            curr = which.Add(curr);
        }
        lt.Append(ge);
        return lt.Head;
    }
}

