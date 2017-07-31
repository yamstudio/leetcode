#define max(a, b) ((a) > (b) ? (a) : (b))

int maxCoins(int* nums, int numsSize) {
    int *new_nums, **dp, *temp, i, j, len, left, right, curr, ret;
    
    if (! numsSize)
        return 0;
    len = numsSize + 2;
    
    new_nums = (int *)malloc(len * sizeof(int));
    new_nums[0] = 1;
    memcpy((void *)new_nums + sizeof(int), (void *)nums, numsSize * sizeof(int));
    new_nums[len - 1] = 1;
    
    dp = (int **)malloc(len * sizeof(int *));
    temp = (int *)malloc(len * len * sizeof(int));
    memset((void *)temp, 0, len * len * sizeof(int));
    for (i = 0; i < len; ++i)
        dp[i] = temp + i * len;
    
    for (i = 2; i < len; ++i) {
        for (left = 0; left < len - i; ++left) {
            right = left + i;
            
            for (j = left + 1; j < right; ++j) {
                curr = dp[left][j] + dp[j][right] + new_nums[left] * new_nums[j] * new_nums[right];
                dp[left][right] = max(dp[left][right], curr);
            }
        }
    }
    
    ret = dp[0][len - 1];
    free(temp);
    free(dp);
    free(new_nums);
    
    return ret;
}
