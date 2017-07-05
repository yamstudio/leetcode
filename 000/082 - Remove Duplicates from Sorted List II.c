/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     struct ListNode *next;
 * };
 */
struct ListNode* deleteDuplicates(struct ListNode* head) {
    struct ListNode **pp, *curr, *temp;
    int val;
    
    if (! head)
        return NULL;
    pp = &head;
    curr = head;
    val = head->val - 1;
    head = NULL;
    
    while (curr) {
        temp = curr->next;
        if ((curr->val != val) && ((! temp) || temp->val != curr->val)) {
            *pp = curr;
            pp = &curr->next;
            curr->next = NULL;
        }
        val = curr->val;
        curr = temp;
    }
    
    return head;
}
