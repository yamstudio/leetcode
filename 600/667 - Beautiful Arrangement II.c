/**
 * Return an array of size *returnSize.
 * Note: The returned array must be malloced, assume caller calls free().
 */
int* constructArray(int n, int k, int* returnSize) {
    int *ret, count = 0, i, t = (k + 1) / 2;
    
    ret = (int *)calloc(n, sizeof(int));
    
    for (i = ! (k % 2); t; i += 2)
        ret[i] = t--;
    
    t = (k + 1) / 2 + 1;
    for (i = 0; i < n; ++i) {
        if (! ret[i])
            ret[i] = t++;
    }
        
    *returnSize = n;
    return ret;
}
