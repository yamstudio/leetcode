static int validate(int *nums, int numsSize, int cand) {
    int i, count = 0;
    
    for (i = 0; i < numsSize; ++i)
        count += nums[i] == cand;
    
    return count > numsSize / 3;
}

/**
 * Return an array of size *returnSize.
 * Note: The returned array must be malloced, assume caller calls free().
 */
int* majorityElement(int* nums, int numsSize, int* returnSize) {
    int *ret, count = 0, c1 = 0, c2 = 0, i, curr, n1 = 0, n2 = 0;
    
    ret = (int *)malloc(2 * sizeof(int));
    if (! (nums && numsSize)) {
        *returnSize = 0;
        return ret;
    }
    
    for (i = 0; i < numsSize; ++i) {
        curr = nums[i];
        if (curr == n1)
            ++c1;
        else if (curr == n2)
            ++c2;
        else if (! c1) {
            n1 = curr;
            ++c1;
        } else if (! c2) {
            n2 = curr;
            ++c2;
        } else {
            --c1;
            --c2;
        }
    }
    
    if (validate(nums, numsSize, n1))
        ret[count++] = n1;
    if (n2 != n1 && validate(nums, numsSize, n2))
        ret[count++] = n2;
    
    *returnSize = count;
    return ret;
}
