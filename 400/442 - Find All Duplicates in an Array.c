#define abs(x) ((x) >= 0 ? x : -x)

/**
 * Return an array of size *returnSize.
 * Note: The returned array must be malloced, assume caller calls free().
 */
int* findDuplicates(int* nums, int numsSize, int* returnSize) {
    int *ret = NULL, count = 0, i, n;
    
    if (numsSize) {
        ret = (int *)malloc(numsSize * sizeof(int));
        
        for (i = 0; i < numsSize; ++i) {
            n = abs(nums[i]) - 1;
            if (nums[n] < 0)
                ret[count++] = n + 1;
            else
                nums[n] = -nums[n];
        }
    }
    
    *returnSize = count;
    return ret;
}
