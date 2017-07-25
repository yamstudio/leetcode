static int helper(struct TreeNode *root, int *count_p, int *ret_p) {
    if (! root)
        return 0;
    
    if (helper(root->left, count_p, ret_p))
        return 1;
    else if (! --*count_p) {
        *ret_p = root->val;
        return 1;
    } else
        return helper(root->right, count_p, ret_p);
}

/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     struct TreeNode *left;
 *     struct TreeNode *right;
 * };
 */
int kthSmallest(struct TreeNode* root, int k) {
    int ret;
    
    helper(root, &k, &ret);
    
    return ret;
}
