/**
 * Definition for binary tree with next pointer.
 * struct TreeLinkNode {
 *  int val;
 *  struct TreeLinkNode *left, *right, *next;
 * };
 *
 */
void connect(struct TreeLinkNode *root) {
    struct TreeLinkNode *first = root, **pp;
    
    while (first) {
        root = first;
        first = NULL;
        pp = NULL;
        
        while (root) {
            if (root->left) {
                if (! first)
                    first = root->left;
                if (pp)
                    *pp = root->left;
                pp = &root->left->next;
            }
            
            if (root->right) {
                if (! first)
                    first = root->right;
                if (pp)
                    *pp = root->right;
                pp = &root->right->next;
            }
            
            root = root->next;
        }
    }
}
