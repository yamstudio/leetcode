/*
 * @lc app=leetcode id=1669 lang=csharp
 *
 * [1669] Merge In Between Linked Lists
 */

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
    public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2) {
        var curr = list1;
        for (int i = a; i > 1; --i) {
            curr = curr.next;
        }
        var tmp = curr.next;
        curr.next = list2;
        curr = tmp;
        for (int i = b - a + 1; i > 0; --i) {
            curr = curr.next;
        }
        while (list2.next != null) {
            list2 = list2.next;
        }
        list2.next = curr;
        return list1;
    }
}
// @lc code=end

