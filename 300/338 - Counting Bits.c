/**
 * Return an array of size *returnSize.
 * Note: The returned array must be malloced, assume caller calls free().
 */
int* countBits(int num, int* returnSize) {
    int *ret, i;
    
    ret = (int *)malloc((num + 1) * sizeof(int));
    ret[0] = 0;
    
    for (i = 1; i <= num; ++i)
        ret[i] = ret[i >> 1] + i % 2;
    
    *returnSize = num + 1;
    return ret;
}
