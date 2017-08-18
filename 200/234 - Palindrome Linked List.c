/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     struct ListNode *next;
 * };
 */
bool isPalindrome(struct ListNode* head) {
    struct ListNode *slow = head, *fast = head, *temp, *curr, *prev;
    int count = 1;
    
    if (! (head && head->next))
        return 1;
    
    while (fast->next && fast->next->next) {
        slow = slow->next;
        fast = fast->next->next;
        ++count;
    }
    
    if (fast->next)
        curr = slow->next;
    else
        curr = slow;
    prev = NULL;
    
    while (1) {
        temp = curr->next;
        curr->next = prev;
        
        prev = curr;
        if (temp)
            curr = temp;
        else
            break;
    }
    
    while (count--) {
        if (curr->val != head->val)
            return 0;
        curr = curr->next;
        head = head->next;
    }
    
    return 1;
}
