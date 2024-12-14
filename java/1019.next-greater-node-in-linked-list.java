/*
 * @lc app=leetcode id=1019 lang=java
 *
 * [1019] Next Greater Node In Linked List
 */

import java.util.ArrayList;
import java.util.List;
import java.util.Stack;

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
    public int[] nextLargerNodes(ListNode head) {
        List<Integer> ret = new ArrayList<>();
        Stack<Pair> stack = new Stack<>();
        ListNode curr = head;
        int i = 0;
        while (curr != null) {
            while (!stack.isEmpty() && curr.val > stack.peek().value()) {
                ret.set(stack.pop().index(), curr.val);
            }
            stack.push(new Pair(i++, curr.val));
            ret.add(0);
            curr = curr.next;
        }
        return ret.stream().mapToInt(Integer::intValue).toArray();
    }

    private record Pair(int index, int value) {}
}
// @lc code=end

class ListNode {
    int val;
    ListNode next;
    ListNode() {}
    ListNode(int val) { this.val = val; }
    ListNode(int val, ListNode next) { this.val = val; this.next = next; }
}
