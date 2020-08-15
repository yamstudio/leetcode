/*
 * @lc app=leetcode id=1019 lang=csharp
 *
 * [1019] Next Greater Node In Linked List
 */

using System.Collections.Generic;
using System.Linq;

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
    public int[] NextLargerNodes(ListNode head) {
        var ret = new Dictionary<int, int>();
        var stack = new Stack<(int Index, int Value)>();
        int i;
        for (i = 0; head != null; head = head.next, ++i) {
            int val = head.val;
            while (stack.TryPeek(out var t) && t.Value < val) {
                ret[t.Index] = val;
                stack.Pop();
            }
            stack.Push((Index: i, Value: val));
        }
        return Enumerable
            .Range(0, i)
            .Select(x => ret.TryGetValue(x, out int v) ? v : 0)
            .ToArray();
    }
}
// @lc code=end

