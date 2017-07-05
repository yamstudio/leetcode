/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     struct ListNode *next;
 * };
 */
struct ListNode* deleteDuplicates(struct ListNode* head) {
    struct ListNode **pp, *curr;
    int val;
    
    if (! head)
        return NULL;
    curr = head->next;
    pp = &head->next;
    val = head->val;
    
    while (curr) {
        if (curr->val == val) {
            curr = curr->next;
            *pp = curr;
        } else {
            val = curr->val;
            pp = &curr->next;
        }
    }
    
    return head;
}
