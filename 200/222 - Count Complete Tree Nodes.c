/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     struct TreeNode *left;
 *     struct TreeNode *right;
 * };
 */
int countNodes(struct TreeNode* root) {
    int left = 0, right = 0;
    struct TreeNode *curr;
    
    if (! root)
        return 0;

    curr = root;
    while (curr) {
        ++left;
        curr = curr->left;
    }
    
    curr = root;
    while (curr) {
        ++right;
        curr = curr->right;
    }

    if (left == right)
        return (2 << (left - 1)) - 1;
    else
        return countNodes(root->left) + countNodes(root->right) + 1;
}
