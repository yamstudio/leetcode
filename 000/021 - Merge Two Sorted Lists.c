/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     struct ListNode *next;
 * };
 */
struct ListNode* mergeTwoLists(struct ListNode* l1, struct ListNode* l2) {
    struct ListNode *ret = NULL, **pp = &ret, *curr = NULL;
    
    while (l1 && l2) {
        if (l1->val < l2->val) {
            curr = l1;
            l1 = l1->next;
        } else {
            curr = l2;
            l2 = l2->next;
        }

        *pp = curr;
        curr->next = NULL;
        pp = &curr->next;
    }
    
    *pp = l1 ? l1 : l2;
    
    return ret;
}