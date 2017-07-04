/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     struct ListNode *next;
 * };
 */
struct ListNode* rotateRight(struct ListNode* head, int k) {
    struct ListNode *curr = head;
    int i, len = 1;
    
    if (head == NULL)
        return head;
    
    while (curr->next) {
        curr = curr->next;
        ++len;
    }
    curr->next = head;
    k = len - k % len;
    
    curr = head;
    for (i = 0; i < k - 1; ++i)
        curr = curr->next;
    
    head = curr->next;
    curr->next = NULL;
    
    return head;
}
