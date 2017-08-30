static void helper(struct TreeNode **pp, int is_left, struct TreeNode *root, int v, int d) {
    struct TreeNode *p;
    
    if (! --d) {
        p = (struct TreeNode *)malloc(sizeof(struct TreeNode));
        p->val = v;
        
        if (is_left) {
            p->left = root;
            p->right = NULL;
        } else {
            p->left = NULL;
            p->right = root;
        }
        
        *pp = p;
    } else {
        if (root) {
            helper(&root->left, 1, root->left, v, d);
            helper(&root->right, 0, root->right, v, d);   
        }
    }
}

/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     struct TreeNode *left;
 *     struct TreeNode *right;
 * };
 */
struct TreeNode* addOneRow(struct TreeNode* root, int v, int d) {
    helper(&root, 1, root, v, d);
    return root;
}
