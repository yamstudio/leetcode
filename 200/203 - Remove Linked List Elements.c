/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     struct ListNode *next;
 * };
 */
struct ListNode* removeElements(struct ListNode* head, int val) {
    struct ListNode **pp, *curr;
    
    pp = &head;
    curr = head;
    
    while (curr) {
        if (curr->val == val)
            *pp = curr->next;
        else
            pp = &curr->next;
        curr = curr->next;
    }
    
    return head;
}
