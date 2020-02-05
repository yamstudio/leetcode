/*
 * @lc app=leetcode id=817 lang=csharp
 *
 * [817] Linked List Components
 */

using System.Collections.Generic;

// @lc code=start
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution {
    public int NumComponents(ListNode head, int[] G) {
        var set = new HashSet<int>(G);
        int ret = 0;
        bool p = false;
        while (head != null) {
            if (set.Contains(head.val)) {
                if (!p) {
                    ++ret;
                }
                p = true;
            } else {
                p = false;
            }
            head = head.next;
        }
        return ret;
    }
}
// @lc code=end

