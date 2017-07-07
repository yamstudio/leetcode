/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     struct ListNode *next;
 * };
 */
struct ListNode* reverseBetween(struct ListNode* head, int m, int n) {
    struct ListNode **pp, *curr, *prev, *temp, *r_head;
    int i, len;
    
    if (! head)
        return NULL;
    len = n - m + 1;
    
    pp = &head;
    for (i = 1; i < m; ++i)
        pp = &((*pp)->next);
    
    r_head = *pp;
    curr = r_head;
    prev = NULL;
    for (i = 0; i < len; ++i) {  
        temp = curr->next;
        curr->next = prev;
        prev = curr;
        curr = temp;
    }
    *pp = prev;
    r_head->next = curr;
    
    return head;
}
