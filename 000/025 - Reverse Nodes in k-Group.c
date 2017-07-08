/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     struct ListNode *next;
 * };
 */
struct ListNode* reverseKGroup(struct ListNode* head, int k) {
    struct ListNode **pp, *curr, *prev, *temp, *start;
    int i;

    if (! head)
        return NULL;
    pp = &head;
    curr = head;
    
    while (curr) {
        start = curr;
        prev = NULL;
        i = 0;
        
        while (curr && i < k) {        
            temp = curr->next;
            curr->next = prev;
            prev = curr;
            curr = temp;
            ++i;
        }
        
        if (i < k) {
            curr = prev;
            prev = NULL;
            while (curr) {
                temp = curr->next;
                curr->next = prev;
                prev = curr;
                curr = temp;
            }
            *pp = prev;
        } else {
            start->next = curr;
            *pp = prev;
            pp = &start->next;
        }
    }
    
    return head;
}
