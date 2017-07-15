/**
 * Definition for binary tree with next pointer.
 * struct TreeLinkNode {
 *  int val;
 *  struct TreeLinkNode *left, *right, *next;
 * };
 *
 */
void connect(struct TreeLinkNode *root) {
    struct TreeLinkNode *first = root;

    while (first) {
        root = first;
        first = first->left;
        
        while (root && root->left) {
            root->left->next = root->right;
            root->right->next = root->next ? root->next->left : NULL;
            root = root->next;
        }
    }
}
