/*
 * @lc app=leetcode id=1171 lang=java
 *
 * [1171] Remove Zero Sum Consecutive Nodes from Linked List
 */

import java.util.HashMap;
import java.util.Map;

// @lc code=start

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     int val;
 *     ListNode next;
 *     ListNode() {}
 *     ListNode(int val) { this.val = val; }
 *     ListNode(int val, ListNode next) { this.val = val; this.next = next; }
 * }
 */
class Solution {
    public ListNode removeZeroSumSublists(ListNode head) {
        Map<Integer, ListNode> sumToNode = new HashMap<>();
        ListNode sentinel = new ListNode(0);
        sumToNode.put(0, sentinel);
        sentinel.next = head;
        ListNode curr = head;
        int sum = 0;
        while (curr != null) {
            sum += curr.val;
            ListNode existing = sumToNode.putIfAbsent(sum, curr);
            if (existing != null) {
                ListNode toRemove = existing.next;
                int sumToRemove = sum;
                while (toRemove != curr) {
                    sumToRemove += toRemove.val;
                    sumToNode.remove(sumToRemove);
                    toRemove = toRemove.next;
                }
                existing.next = curr.next;
            }
            curr = curr.next;
        }
        return sentinel.next;
    }
}
// @lc code=end

class ListNode {
    int val;
    ListNode next;
    ListNode() {}
    ListNode(int val) { this.val = val; }
    ListNode(int val, ListNode next) { this.val = val; this.next = next; }
}
