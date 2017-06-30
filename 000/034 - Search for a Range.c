void helper(int * nums, int target, int from, int to, int *start_p, int *end_p) {
    int mid = (from + to) / 2, v;
    
    if (mid == from) {
        if (start_p) {
            if (nums[from] == target)
                *start_p = from;
            else if (nums[to] == target)
                *start_p = to;
        }
        if (end_p) {
            if (nums[to] == target)
                *end_p = to;
            else if (nums[from] == target)
                *end_p = from;
        }
        return;
    }
    
    v = nums[mid];
    if (v == target) {
        if (start_p)
            helper(nums, target, from, mid, start_p, NULL);
        if (end_p)
            helper(nums, target, mid, to, NULL, end_p);
    } else if (v < target) {
        helper(nums, target, mid, to, start_p, end_p);
    } else {
        helper(nums, target, from, mid, start_p, end_p);
    }
}

/**
 * Return an array of size *returnSize.
 * Note: The returned array must be malloced, assume caller calls free().
 */
int* searchRange(int* nums, int numsSize, int target, int* returnSize) {
    int left = 0, right = numsSize - 1, start = -1, end = -1, *ret;
    
    if(numsSize)
        helper(nums, target, 0, numsSize - 1, &start, &end);
        
    ret = (int *)malloc(2 * sizeof(int));
    ret[0] = start;
    ret[1] = end;
    *returnSize = 2;
    
    return ret;
}
