/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     struct TreeNode *left;
 *     struct TreeNode *right;
 * };
 */
struct TreeNode* insertIntoBST(struct TreeNode* root, int val) {
    if (!root) {
        struct TreeNode * ret = malloc(sizeof(struct TreeNode));
        ret->val = val;
        ret->left = NULL;
        ret->right = NULL;
        return ret;
    }
    
    if (val < root->val) {
        root->left = insertIntoBST(root->left, val);
    } else {
        root->right = insertIntoBST(root->right, val);
    }
    
    return root;
}