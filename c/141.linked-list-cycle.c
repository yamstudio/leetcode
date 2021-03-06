/*
 * @lc app=leetcode id=141 lang=c
 *
 * [141] Linked List Cycle
 *
 * autogenerated using scripts/convert.py
 */
/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     struct ListNode *next;
 * };
 */
bool hasCycle(struct ListNode *head) {
    struct ListNode *slow = head, *fast = head;
    
    if (! head)
        return 0;
    
    do {
        if (! (fast->next && fast->next->next))
            return 0;
        fast = fast->next->next;
        slow = slow->next;
    } while (slow != fast);
    
    return 1;
}
