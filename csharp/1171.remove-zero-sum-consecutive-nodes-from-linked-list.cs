/*
 * @lc app=leetcode id=1171 lang=csharp
 *
 * [1171] Remove Zero Sum Consecutive Nodes from Linked List
 */

using System.Collections.Generic;

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode RemoveZeroSumSublists(ListNode head) {
        var sentinel = new ListNode();
        var map = new Dictionary<int, ListNode>();
        int acc = 0;
        sentinel.next = head;
        map[0] = sentinel;
        while (head != null) {
            acc += head.val;
            if (map.TryGetValue(acc, out var p)) {
                var rm = p.next;
                int b = acc + rm.val;
                while (b != acc) {
                    map.Remove(b);
                    rm = rm.next;
                    b += rm.val;
                }
                p.next = head.next;
            } else {
                map[acc] = head;
            }
            head = head.next;
        }
        return sentinel.next;
    }
}
// @lc code=end

