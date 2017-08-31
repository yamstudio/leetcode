#include <limits.h>

static struct TreeNode *helper(int *nums, int from, int to) {
    int m = INT_MIN, mi = -1, i;
    struct TreeNode *ret;
    
    if (from > to)
        return NULL;
    
    for (i = from; i <= to; ++i) {
        if (nums[i] > m) {
            m = nums[i];
            mi = i;
        }
    }
    
    ret = (struct TreeNode *)malloc(sizeof(struct TreeNode));
    ret->val = m;
    ret->left = helper(nums, from, mi - 1);
    ret->right = helper(nums, mi + 1, to);
    
    return ret;
}

/**
 * Definition for a binary tree node.
 * struct TreeNode {
 *     int val;
 *     struct TreeNode *left;
 *     struct TreeNode *right;
 * };
 */
struct TreeNode* constructMaximumBinaryTree(int* nums, int numsSize) {
    return helper(nums, 0, numsSize - 1);
}
