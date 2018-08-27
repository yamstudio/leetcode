/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     struct TreeNode *left;
 *     struct TreeNode *right;
 * };
 */

#define max(a, b) ((a) > (b) ? (a) : (b))

static int search(struct TreeNode *root, int *ret) {
    struct TreeNode *left = root->left, *right = root->right;
    int my = 0, path = 0;

    if (left) {
        int lret = search(left, ret);
        if (left->val == root->val) {
            my = 1 + lret;
            path = my;
        }
    }
    
    if (right) {
        int rret = search(right, ret);
        if (right->val == root->val) {
            if (rret >= my) {
                my = 1 + rret;
            }
            path += 1 + rret;
        }
    }
    
    *ret = max(*ret, path);
    
    return my;
}

int longestUnivaluePath(struct TreeNode* root) {
    int ret = 0;
    
    if (root)
        search(root, &ret);
    
    return ret;
}