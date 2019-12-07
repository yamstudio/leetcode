/*
 * @lc app=leetcode id=725 lang=csharp
 *
 * [725] Split Linked List in Parts
 */

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
    public ListNode[] SplitListToParts(ListNode root, int k) {
        ListNode[] ret = new ListNode[k];
        int len = 0;
        ListNode curr = root;
        while (curr != null) {
            ++len;
            curr = curr.next;
        }
        for (int i = 0; i < k; ++i) {
            int count = len / k + (i < len % k ? 1 : 0);
            if (count == 0) {
                break;
            }
            ret[i] = root;
            for (int j = 1; j < count; ++j) {
                root = root.next;
            }
            curr = root.next;
            root.next = null;
            root = curr;
        }
        return ret;
    }
}
// @lc code=end

