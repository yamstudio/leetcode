/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     struct TreeNode *left;
 *     struct TreeNode *right;
 * };
 */
struct TreeNode* trimBST(struct TreeNode* root, int L, int R) {
    if (!root) {
        return NULL;
    }
    
    struct TreeNode *left = trimBST(root->left, L, R), *right = trimBST(root->right, L, R);
    
    if (root->val < L) {
        return right;
    } else if (root->val > R) {
        return left;
    } else {
        root->left = left;
        root->right = right;
        return root;
    }
}