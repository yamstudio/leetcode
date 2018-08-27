/**
 * Definition for singly-linked list.
 * struct ListNode {
 *     int val;
 *     struct ListNode *next;
 * };
 */
/**
 * Return an array of size *returnSize.
 * Note: The returned array must be malloced, assume caller calls free().
 */
struct ListNode** splitListToParts(struct ListNode* root, int k, int* returnSize) {
    struct ListNode **ret = calloc(k, sizeof(struct ListNode *));
    int len = 0;
    
    for (struct ListNode *curr = root; curr; curr = curr->next) {
        ++len;
    }
    
    int q = len / k, r = len % k;
    
    for (int i = 0; i < k && root; ++i) {
        ret[i] = root;
        int count = q + (i < r);
        for (int j = 1; j < count; ++j) {
            root = root->next;
        }
        
        struct TreeNode *temp = root->next;
        root->next = NULL;
        root = temp;
    }
    
    *returnSize = k;
    return ret;
}