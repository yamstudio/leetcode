/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     struct ListNode *next;
 * };
 */
struct ListNode* removeNthFromEnd(struct ListNode* head, int n) {
    struct ListNode **pp = &head, *ans = head, *tail = head;
    int k = n - 1;
    
    while (k--) {
        tail = tail->next;
    }
    
    while (tail->next) {
        pp = &ans->next;
        ans = ans->next;
        tail = tail->next;
    }
    *pp = ans->next;
    return head;
}
