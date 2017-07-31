/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     struct ListNode *next;
 * };
 */
struct ListNode* oddEvenList(struct ListNode* head) {
    struct ListNode *even = NULL, **opp, **epp, ***ppp, *curr, *temp;
    int c = 1;
    
    if (! head)
        return NULL;
    opp = &head;
    epp = &even;
    curr = head;
    
    while (curr) {
        temp = curr->next;
        curr->next = NULL;
        
        ppp = c % 2 ? &opp : &epp;
        **ppp = curr;
        *ppp = &curr->next;

        curr = temp;
        c++;
    }
    
    *opp = even;
    return head;
}
