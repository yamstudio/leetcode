/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     struct ListNode *next;
 * };
 */
void reorderList(struct ListNode* head) {
    struct ListNode *temp = head, *last = head, *curr;
    
    if (! (head && head->next))
        return;
    
    while (1) {
        if (last->next)
            last = last->next;
        else break;
        
        if (last->next)
            last = last->next;
        else break;
        
        temp = temp->next;
    }
    
    last = temp->next;
    temp->next = NULL;
    curr = last->next;
    last->next = NULL;
    while (curr) {
        temp = curr->next;
        curr->next = last;
        last = curr;
        curr = temp;
    }
    
    curr = head;
    while (last) {
        temp = curr->next;
        curr->next = last;
        curr = temp;
        temp = last->next;
        last->next = curr;
        last = temp;
    }
}
